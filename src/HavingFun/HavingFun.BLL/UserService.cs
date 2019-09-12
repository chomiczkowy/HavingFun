using HavingFun.Common.Consts;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.DapperDAL;
using HavingFun.EFDAL;
using HavingFun.EFDAL.AggregateRoots;
using HavingFun.EFDAL.Entities;
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
        private IPasswordHasher _passwordHasher;

        public UserService(CommandRepositoriesContainer cmdContainer, QueryRepositoriesContainer queryContainer,
            IPasswordHasher passwordHasher)
        {
            _cmdContainer = cmdContainer;
            _queryContainer = queryContainer;
            _passwordHasher = passwordHasher;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _queryContainer.UserQueryRepository.GetByUserName<UserModel>(username);

            // return null if user not found
            if (user == null || user.PasswordHash != _passwordHasher.HashPassword(password))
                return null;

            return new UserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Claims = new System.Security.Claims.Claim[0] //TODO
            };
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

        public int? Create(UserLoginModel userModel)
        {
            var userAggregate = _cmdContainer.UserCommandRepository.GetForAdd();
            return userAggregate.AddNew(userModel, _passwordHasher);
        }

        public UserModel GetById(int id)
        {
            return _queryContainer.UserQueryRepository.GetById<UserModel>(id);
        }
    }
}
