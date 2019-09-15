using Dapper;
using HavingFun.Common.Interfaces.DAL;
using HavingFun.Common.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                return conn.QuerySingleOrDefault<TQueryModel>("SELECT u.* from \"schUsers\".\"Users\" u WHERE u.\"Id\" = @id", new { id });
            }
        }

        private class ClaimModel
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }

        public UserModel GetByUserName(string userName)
        {
            const string sql = "SELECT u.* from \"schUsers\".\"Users\" u WHERE u.\"Username\" = @username;" + @"
                    " + "SELECT c.* from \"schUsers\".\"UserClaims\" uc INNER JOIN \"schUsers\".\"Claims\" c on c.\"Id\"= uc.\"ClaimId\" WHERE uc.\"UserId\" = (SELECT u2.\"Id\" from \"schUsers\".\"Users\" u2 WHERE u2.\"Username\" = @username);";
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                var reader = conn.QueryMultiple(sql, new { username = userName });

                var user = reader.Read<UserModel>().Single();
                var claims = reader.Read<ClaimModel>().ToList();
                user.Claims = claims.Select(x => new System.Security.Claims.Claim(x.Type, x.Value)).ToArray();

                return user;
            }
        }

        public PageableQueryResult<TQueryModel> GetPage<TQueryModel>(int pageSize, int pageNumber)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                var count = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM \"schUsers\".\"Users\"");
                var itemsOnPage = conn.Query<TQueryModel>($"SELECT u.* from \"schUsers\".\"Users\" u ORDER BY u.\"Id\" LIMIT @pageSize OFFSET @minRowNumExcl",
                    new { minRowNumExcl = pageSize * pageNumber, pageSize = pageSize });

                return new PageableQueryResult<TQueryModel>()
                {
                    AllItemsCount = count,
                    Items = itemsOnPage
                };
            }
        }
    }
}
