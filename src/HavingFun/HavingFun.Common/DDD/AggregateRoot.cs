using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.DDD
{
    public class AggregateRoot<TEntity>
    {
        protected TEntity _entity;

        protected AggregateRoot(TEntity entity)
        {
            _entity = entity;
        }
    }
}
