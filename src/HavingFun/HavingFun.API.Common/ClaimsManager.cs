using HavingFun.Common;
using HavingFun.Common.Consts;
using HavingFun.Common.Exceptions;
using HavingFun.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HavingFun.API.Common
{
    public static class ClaimsManager
    {
        public static string GetStringClaimValue(this HttpRequest httpRequest, string claimType)
        {
            string claimStrValue = httpRequest.HttpContext.User.FindFirst(CustomClaims.UserId)?.Value;
            if (string.IsNullOrEmpty(claimStrValue))
            {
                throw new HavingFunSecurityException($"No {claimType} claim");
            }

            return claimStrValue;
        }

        public static int GetIntClaimValue(this HttpRequest httpRequest, string claimType)
        {
            var stringVal = GetStringClaimValue(httpRequest, claimType);

            int intVal = 0;
            if (!int.TryParse(stringVal, out intVal))
            {
                throw new HavingFunSecurityException($"Invalid {claimType} claim: {stringVal}");
            }

            return intVal;
        }

        public static bool GetBoolClaimValue(this HttpRequest httpRequest, string claimType)
        {
            var stringVal = GetStringClaimValue(httpRequest, claimType);

            return ConvertClaimToBool(claimType, stringVal);
        }

        private static bool ConvertClaimToBool(string claimType, string stringVal)
        {
            if (stringVal == ClaimsDefaultValues.Allow)
                return true;

            bool boolVal = false;
            if (!bool.TryParse(stringVal, out boolVal))
            {
                throw new HavingFunSecurityException($"Invalid {claimType} claim: {stringVal}");
            }

            return boolVal;
        }

        public static Command<T> ToCommand<T>(this HttpRequest httpRequest, T model, bool isAnonymous = false)
        {
            var command = new Command<T>(model);
            if (!isAnonymous)
            {
                command.ExecutingUserId = GetIntClaimValue(httpRequest, CustomClaims.UserId);
            }
            return command;
        }

        public static Query<T> ToQuery<T>(this HttpRequest httpRequest, T model, bool isAnonymous = false)
        {
            var query = new Query<T>(model);
            if (!isAnonymous)
            {
                query.ExecutingUserId = GetIntClaimValue(httpRequest, CustomClaims.UserId);
            }
            return query;
        }

        public static bool UserHasRequiredPermissions(this HttpRequest request, params string[] sufficientClaims)
        {
            var userClaims = request.HttpContext.User.Claims.Where(x => sufficientClaims.Contains(x.Type)).ToList();
            foreach (var userClaim in userClaims)
            {
                if (ConvertClaimToBool(userClaim.Type, userClaim.Value))
                    return true;
            }

            return false;
        }
    }
}
