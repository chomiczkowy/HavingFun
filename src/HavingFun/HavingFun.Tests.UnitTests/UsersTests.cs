using HavingFun.Common.Exceptions;
using HavingFun.Common.Helpers;
using HavingFun.Common.Models;
using HavingFun.EFDAL.AggregateRoots;
using HavingFun.EFDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace HavingFun.Tests.UnitTests
{
    [TestClass]
    public class UsersTests
    {
        [TestMethod]
        public void RegisteringUser_WhenGivenUsernameExists_Fails()
        {
            var dbContext = DbContextProvider.CreateMainDbForTests(MethodBase.GetCurrentMethod().Name);
            var aggregateRoot = new UserAggregateRoot(null, dbContext);
            const string testedUserName = "testUser";

            dbContext.Users.Add(new EFDAL.Entities.User()
            {
                FirstName = "aa",
                LastName = "bb",
                EmailAddress = "cc@ddd.com",
                PasswordHash = "abcdefgh",
                Id = 4,
                Username = testedUserName,
            });
            dbContext.SaveChanges();

            var userModel = new EditUserModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                EmailAddress = "test@email.com",
                Password = "testPassword",
                Username = testedUserName
            };

            Assert.ThrowsException<HavingFunBusinessValidationException>(() => aggregateRoot.AddNew(userModel, new SHA256PasswordHasher()));
        }

        [TestMethod]
        public void RegisteringUser_WhenGivenUsernameNotExists_AddsUser()
        {
            var dbContext = DbContextProvider.CreateMainDbForTests(MethodBase.GetCurrentMethod().Name);
            var aggregateRoot = new UserAggregateRoot(null, dbContext);

            const string alreadyAddedUserName = "testUser";
            const string testedUserName = "testUserDifferent";


            dbContext.Users.Add(new EFDAL.Entities.User()
            {
                FirstName = "aa",
                LastName = "bb",
                EmailAddress = "cc@ddd.com",
                PasswordHash = "abcdefgh",
                Id = 4,
                Username = alreadyAddedUserName,
            });
            dbContext.SaveChanges();

            var userModel = new EditUserModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                EmailAddress = "test@email.com",
                Password = "testPassword",
                Username = testedUserName
            };
            aggregateRoot.AddNew(userModel, new SHA256PasswordHasher());

            Assert.AreEqual(2, dbContext.Users.Count());
            Assert.IsNotNull(dbContext.Users.Single(x => x.Username == testedUserName));
        }
    }
}
