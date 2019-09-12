using HavingFun.Common.Interfaces.DAL;
using HavingFun.EFDAL.Context;
using HavingFun.EFDAL.AggregateRoots;
using HavingFun.EFDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace HavingFun.EFDAL.Repositories
{
    public class UserCommandRepository : ICommandRepository<int, User, MainDBContext, UserAggregateRoot>
    {
        private MainDBContext _dbContext;

        public UserCommandRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserAggregateRoot GetForUpdate(int key)
        {
            var user= _dbContext.Users.Find(key);
            return new UserAggregateRoot(user, _dbContext);
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public UserAggregateRoot GetForAdd()
        {
            return new UserAggregateRoot(null, _dbContext);
        }
    }
}
