using HavingFun.Common.Consts;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.EFDAL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HavingFun.BLL
{
    public class UserService : IUserService
    {
        private CommandRepositoriesContainer _container;

        public UserService(CommandRepositoriesContainer container)
        {
            _container = container;
        }

        public User Authenticate(string username, string password)
        {
            var user = _container.UserQueryRepository.GetById(username);

            // return null if user not found
            if (user == null || user.PasswordHash != HashPassword(password))
                return null;

            return new User()
            {
                Username = user.UserName,
                FirstName = user.UserName,
                LastName = user.UserName,
                Claims = new Claim[0] //TODO
            };
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public PageableQueryResult<User> GetAll(int pageSize, int pageNumber)
        {
            var result = _container.UserQueryRepository.GetAll(pageSize, pageNumber);

            return new PageableQueryResult<User>()
            {
                Items = result.Items.Select(x => new User
                {
                    Id = 1, //TODO
                    FirstName = x.UserName,
                    LastName = x.UserName,
                    Username = x.UserName
                }).ToArray(),
                AllItemsCount = result.AllItemsCount
            };
        }
    }
}
