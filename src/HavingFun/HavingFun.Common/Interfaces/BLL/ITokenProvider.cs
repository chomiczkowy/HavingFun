using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
   public interface ITokenProvider
    {
        string CreateToken(UserModel user, string secret);
        IEnumerable<Claim> GetClaims(string token);
    }
}
