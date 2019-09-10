using Dapper;
using HavingFun.Common.Interfaces.DAL;
using HavingFun.Common.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HavingFun.DapperDAL.Repositories
{
    public class UserQueryRepository : IQueryRepository<int>
    {
        private string _connectionString;

        public UserQueryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TQueryModel GetById<TQueryModel>(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                return conn.QuerySingle<TQueryModel>("SELECT * from schUsers.Users u WHERE u.Id = " + id);
            }
        }

        public TQueryModel GetByUserName<TQueryModel>(string userName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                return conn.QuerySingleOrDefault<TQueryModel>("SELECT * from \"schUsers\".\"Users\" u WHERE u.\"Username\" = @username", new { username = userName });
            }
        }

        public PageableQueryResult<TQueryModel> GetPage<TQueryModel>(int pageSize, int pageNumber)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                var count = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM \"schUsers.Users\"");
                var itemsOnPage = conn.Query<TQueryModel>($"SELECT u.*, row_number() OVER (ORDER BY Id) as rnum from \"schUsers\".\"Users\" u WHERE rnum > @minRowNumExcl AND rnum <= @maxRowIncl",
                    new { minRowNumExcl= pageSize * pageNumber , maxRowIncl= pageSize * (pageNumber + 1) });

                return new PageableQueryResult<TQueryModel>()
                {
                    AllItemsCount = count,
                    Items = itemsOnPage
                };
            }
        }
    }
}
