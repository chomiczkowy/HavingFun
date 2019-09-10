using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.DAL
{
    public interface IQueryRepository<TKey>
    {
        TQueryModel GetById<TQueryModel>(TKey id);
        PageableQueryResult<TQueryModel> GetPage<TQueryModel>(int pageSize, int pageNumber);
    }
}
