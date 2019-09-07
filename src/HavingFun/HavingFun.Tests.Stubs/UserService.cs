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
    public class UserService : IUserService
    {
        private static readonly List<User> _users;

        static UserService()
        {
            _users = new List<User>();

            for (var i = 1; i <= 200; i++)
            {
                var user = new User { Id = 1, FirstName = "Test_" + i, LastName = "User_" + i, Username = "test" + i, Password = "test" + i };
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

        public UserService()
        {
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            return new User()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Claims = user.Claims
            };
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Username = x.Username
            }).ToArray();
        }
    }
}
