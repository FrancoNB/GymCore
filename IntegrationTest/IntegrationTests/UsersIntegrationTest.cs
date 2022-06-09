using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class UsersIntegrationTest
    {
        private UsersModel users;
        private static Random random;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            random = new Random();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            users = new UsersModel()
            {
                IdUsers = 1,
                Username = "UserValid" + random.Next().ToString(),
                Password = "PasswordValid"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            users.Operation = Operation.Insert;

            AcctionResult acctionResult = await users.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            users.Operation = Operation.Update;

            AcctionResult acctionResult = await users.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            users.Operation = Operation.Delete;

            AcctionResult acctionResult = await users.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await users.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            users.IdUsers = await users.GetLastId();

            Assert.IsTrue(users.IdUsers > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}