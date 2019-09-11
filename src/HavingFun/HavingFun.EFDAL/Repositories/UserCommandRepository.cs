using HavingFun.Common.Interfaces.DAL;
using HavingFun.EFDA.Context;
using HavingFun.EFDAL.AggregateRoots;
using HavingFun.EFDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace HavingFun.EFDAL.Repositories
{
    public class UserCommandRepository : ICommandRepository<int, User, UserAggregateRoot>
    {
        private MainDBContext _dbContext;

        public UserCommandRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(User entity)
        {
            throw new NotImplementedException();
        }

        public UserAggregateRoot GetForUpdate(int key)
        {
            var user= _dbContext.Users.Find(key);
            return new UserAggregateRoot(user);
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
