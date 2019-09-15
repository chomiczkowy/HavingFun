using HavingFun.EFDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace HavingFun.Tests.UnitTests
{
    public static class DbContextProvider
    {
        public static MainDBContext CreateMainDbForTests(string testName)
        {
            var options = new DbContextOptionsBuilder<MainDBContext>()
             .UseInMemoryDatabase(databaseName: testName)
             .Options;

            return new MainDBContext(options);
        }
    }
}
