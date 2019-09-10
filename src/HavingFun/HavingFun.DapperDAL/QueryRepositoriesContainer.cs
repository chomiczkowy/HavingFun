using HavingFun.DapperDAL.Repositories;

namespace HavingFun.DapperDAL
{
    public class QueryRepositoriesContainer
    {
        public UserQueryRepository UserQueryRepository { get; set; }

        public QueryRepositoriesContainer(string connectionString)
        {
            UserQueryRepository = new UserQueryRepository(connectionString);
        }
    }
}
