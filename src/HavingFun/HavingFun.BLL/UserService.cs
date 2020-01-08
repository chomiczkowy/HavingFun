using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Messages;
using HavingFun.Common.Models;
using HavingFun.DapperDAL;
using HavingFun.EFDAL;
using MassTransit;
using System;
using System.Linq;

namespace HavingFun.BLL
{
    public class UserService : IUserService
    {
        private CommandRepositoriesContainer _cmdContainer;
        private QueryRepositoriesContainer _queryContainer;
        private IPasswordHasher _passwordHasher;
        private IBus _bus;

        public UserService(CommandRepositoriesContainer cmdContainer, QueryRepositoriesContainer queryContainer,
            IPasswordHasher passwordHasher, IBus bus)
        {
            _cmdContainer = cmdContainer;
            _queryContainer = queryContainer;
            _passwordHasher = passwordHasher;
            _bus = bus;
        }

        public UserModel Authenticate(Command<UserLoginModel> cmd)
        {
            var user = _queryContainer.UserQueryRepository.GetByUserName(cmd.Data.Username);

            // return null if user not found
            if (user == null || user.PasswordHash != _passwordHasher.HashPassword(cmd.Data.Password))
                return null;

            return new UserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Claims = user.Claims.ToArray(),
                Id = user.Id,
                EmailAddress = user.EmailAddress
            };
        }


        public PageableQueryResult<UserModel> GetPage(Query<PageableQuery> query)
        {
            var result = _queryContainer.UserQueryRepository.GetPage<UserModel>(query.Data.PageSize, query.Data.PageNumber);
            return result;
        }

        public int? Create(Command<EditUserModel> cmd)
        {
            var userAggregate = _cmdContainer.UserCommandRepository.GetForAdd();
            var createdUserId= userAggregate.AddNew(cmd.Data, _passwordHasher);
            _bus.Publish(new UserCreatedMessage()
            {
                UserId = createdUserId,
                CreatedDate = DateTime.Now
            });

            return createdUserId;
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
            return _queryContainer.UserQueryRepository.GetByUserName(query.Data);
        }
    }
}
