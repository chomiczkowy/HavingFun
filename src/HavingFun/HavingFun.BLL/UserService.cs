using HavingFun.Common.Consts;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.DapperDAL;
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
        private CommandRepositoriesContainer _cmdContainer;
        private QueryRepositoriesContainer _queryContainer;

        public UserService(CommandRepositoriesContainer cmdContainer, QueryRepositoriesContainer queryContainer)
        {
            _cmdContainer = cmdContainer;
            _queryContainer = queryContainer;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _queryContainer.UserQueryRepository.GetByUserName<UserModel>(username);

            // return null if user not found
            if (user == null || user.PasswordHash != HashPassword(password))
                return null;

            return new UserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

        public PageableQueryResult<UserModel> GetPage(int pageSize, int pageNumber)
        {
            var result = _queryContainer.UserQueryRepository.GetPage<UserModel>(pageSize, pageNumber);

            return new PageableQueryResult<UserModel>()
            {
                Items = result.Items.Select(x => new UserModel
                {
                    Id = 1, //TODO
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username
                }).ToArray(),
                AllItemsCount = result.AllItemsCount
            };
        }
    }
}
