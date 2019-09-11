using HavingFun.Common.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface ICommandRepository<TKey, TEntity, TAggregateRoot> where TAggregateRoot: AggregateRoot<TEntity>
    {
        TKey Add(TAggregateRoot entity);
        TAggregateRoot GetForUpdate(TKey key);
        void Remove(TEntity entity);
        void SaveChanges();
    }
}
