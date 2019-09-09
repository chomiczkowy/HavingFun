using HavingFun.Common.Interfaces.DAL;
using HavingFun.Common.Models;
using HavingFun.EFDA.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace HavingFun.EFDAL.Repositories
{
    public class UserCommandRepository : ICommandRepository<IdentityUser, string>
    {
        private MainDBContext _dbContext;

        public UserCommandRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(IdentityUser entity)
        {
            throw new NotImplementedException();
        }
    }

    public class UserQueryRepository : IQueryRepository<IdentityUser, string>
    {
        private MainDBContext _dbContext;

        public UserQueryRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PageableQueryResult<IdentityUser> GetAll(int pageSize, int pageNumber)
        {
            return new PageableQueryResult<IdentityUser>()
            {
                Items = _dbContext.Users.Skip(pageSize * pageNumber).Take(pageSize).ToArray(),
                AllItemsCount = _dbContext.Users.Count()
            };
        }

        public IdentityUser GetById(string id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}
