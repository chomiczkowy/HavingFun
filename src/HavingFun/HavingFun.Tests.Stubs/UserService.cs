using HavingFun.Common.AppSettings;
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

        private readonly CustomSettings _appSettings;

        static UserService()
        {
            _users = new List<User>();

            for (var i = 1; i <= 200; i++)
            {
                _users.Add(new User { Id = 1, FirstName = "Test_" + i, LastName = "User_" + i, Username = "test" + i, Password = "test" + i });
            }
        }

        public UserService(IOptions<CustomSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}
