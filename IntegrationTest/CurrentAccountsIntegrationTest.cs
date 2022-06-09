using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class CurrentAccountsIntegrationTest
    {
        private CurrentAccountsModel currentAccounts;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            currentAccounts = new CurrentAccountsModel()
            {
                IdClients = 1,
                TicketCode = Tickets.Create("SUB", 1),
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            currentAccounts.Operation = Operation.Insert;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            currentAccounts.Operation = Operation.Insert;
            currentAccounts.TicketCode = null;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            currentAccounts.Operation = Operation.Insert;
            currentAccounts.IdClients = 0;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            currentAccounts.Operation = Operation.Update;

            await GetLastId_ValidTest();

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            currentAccounts.Operation = Operation.Update;
            currentAccounts.IdClients = 0;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            currentAccounts.Operation = Operation.Update;
            currentAccounts.IdCurrentAccounts = 0;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3()
        {
            await GetLastId_ValidTest();

            currentAccounts.Operation = Operation.Update;
            currentAccounts.TicketCode = null;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            currentAccounts.Operation = Operation.Delete;

            await GetLastId_ValidTest();

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            currentAccounts.IdCurrentAccounts = await currentAccounts.GetLastId();

            Assert.IsTrue(currentAccounts.IdCurrentAccounts > 0);
        }
        
        [TestMethod]
        public async Task GetLastId_InvalidTest()
        {
            await Insert_ValidTest();
            currentAccounts.IdCurrentAccounts = 0;

            currentAccounts.IdCurrentAccounts = await currentAccounts.GetLastId();

            Assert.IsTrue(currentAccounts.IdCurrentAccounts > 0);
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
