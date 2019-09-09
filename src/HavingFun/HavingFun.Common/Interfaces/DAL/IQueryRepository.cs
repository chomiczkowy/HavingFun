using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface IQueryRepository<TEntity, TKey>
    {
        TEntity GetById(TKey id);
        PageableQueryResult<TEntity> GetAll(int pageSize, int pageNumber);
    }
}
