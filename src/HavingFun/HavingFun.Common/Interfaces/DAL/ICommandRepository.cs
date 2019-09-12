using HavingFun.Common.DDD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface ICommandRepository<TKey, TEntity, TContext, TAggregateRoot> where TAggregateRoot: AggregateRoot<TEntity, TContext>
                                                                                where TContext: DbContext
    {
        TAggregateRoot GetForAdd();
        TAggregateRoot GetForUpdate(TKey key);
        void Remove(TEntity entity);
        void SaveChanges();
    }
}
