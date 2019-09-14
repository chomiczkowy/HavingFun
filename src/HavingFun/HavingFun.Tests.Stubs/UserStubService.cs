using HavingFun.Common.Consts;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HavingFun.Tests.Stubs
{
    public class UserStubService : IUserService
    {
        private static readonly List<UserStubModel> _users;

        static UserStubService()
        {
            _users = new List<UserStubModel>();

            for (var i = 1; i <= 200; i++)
            {
                var user = new UserStubModel { Id = 1, FirstName = "Test_" + i, LastName = "User_" + i, Username = "test" + i, Password = "test" + i };
                var claimsList = new List<Claim>();
                claimsList.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

                if (i % 2 == 0)
                {
                    claimsList.Add(new Claim(CustomClaims.CanSeeUsersList, ClaimsDefaultValues.Allow));
                }

                user.Claims = claimsList;

                _users.Add(user);
            }
        }

        private IPasswordHasher _passwordHasher;

        public UserStubService(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public UserModel Authenticate(Command<UserLoginModel> cmd)
        {
            var user = _users.SingleOrDefault(x => x.Username == cmd.Data.Username && x.Password == cmd.Data.Password);
           
            // return null if user not found
            if (user == null)
                return null;

            return new UserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Claims = user.Claims
            };
        }

        public int? Create(Command<EditUserModel> userModel)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(Query<int> id)
        {
            throw new NotImplementedException();
        }

        public PageableQueryResult<UserModel> GetPage(Query<PageableQueryParameters> query)
        {
            // return users without passwords
            return new PageableQueryResult<UserModel>()
            {
                Items = _users.Skip(query.Data.PageSize * query.Data.PageNumber).Take(query.Data.PageSize).Select(x => new UserModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username
                }).ToArray(),
                AllItemsCount = _users.Count
            };
        }

        public object Update(Command<EditUserModel> cmd)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByName(Query<string> query)
        {
            throw new NotImplementedException();
        }
    }
}
