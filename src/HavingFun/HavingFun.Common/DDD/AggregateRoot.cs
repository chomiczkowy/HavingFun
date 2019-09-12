using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.DDD
{
    public class AggregateRoot<TEntity, TContext> where TContext : DbContext
    {
        protected TEntity _entity;
        protected TContext _context;

        protected AggregateRoot(TEntity entity, TContext context)
        {
            _entity = entity;
            _context = context;
        }
    }
}
