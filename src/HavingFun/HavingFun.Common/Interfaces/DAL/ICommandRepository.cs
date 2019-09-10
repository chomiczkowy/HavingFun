using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface ICommandRepository<TEntity, TKey, TAggregateRoot>
    {
        TKey Add(TEntity entity);
        TAggregateRoot GetForUpdate(TKey key);
        void Remove(TEntity entity);
        void SaveChanges();
    }
}
