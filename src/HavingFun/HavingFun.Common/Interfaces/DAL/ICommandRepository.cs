using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface ICommandRepository<TEntity, TKey>
    {
        TKey Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
    }
}
