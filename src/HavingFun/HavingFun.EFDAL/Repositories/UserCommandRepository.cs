using HavingFun.Common.Interfaces.DAL;
using HavingFun.EFDA.Context;
using HavingFun.EFDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace HavingFun.EFDAL.Repositories
{
    public class UserCommandRepository : ICommandRepository<User, string, User>
    {
        private MainDBContext _dbContext;

        public UserCommandRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetForUpdate(string key)
        {
            throw new NotImplementedException();
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
