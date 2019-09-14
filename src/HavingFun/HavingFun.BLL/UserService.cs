﻿using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.DapperDAL;
using HavingFun.EFDAL;
using System;
using System.Linq;

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

        public UserModel Authenticate(Command<UserLoginModel> cmd)
        {
            var user = _queryContainer.UserQueryRepository.GetByUserName<UserModel>(cmd.Data.Username);

            // return null if user not found
            if (user == null || user.PasswordHash != _passwordHasher.HashPassword(cmd.Data.Password))
                return null;

            return new UserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Claims = new System.Security.Claims.Claim[0] //TODO
            };
        }


        public PageableQueryResult<UserModel> GetPage(Query<PageableQueryParameters> query)
        {
            var result = _queryContainer.UserQueryRepository.GetPage<UserModel>(query.Data.PageSize, query.Data.PageNumber);
            return result;
        }

        public int? Create(Command<EditUserModel> cmd)
        {
            var userAggregate = _cmdContainer.UserCommandRepository.GetForAdd();
            return userAggregate.AddNew(cmd.Data, _passwordHasher);
        }

        public UserModel GetById(Query<int> query)
        {
            return _queryContainer.UserQueryRepository.GetById<UserModel>(query.Data);
        }

        public object Update(Command<EditUserModel> cmd)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByName(Query<string> query)
        {
            return _queryContainer.UserQueryRepository.GetByUserName<UserModel>(query.Data);
        }
    }
}
