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
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            currentAccounts.Operation = Operation.Update;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            currentAccounts.Operation = Operation.Delete;

            AcctionResult acctionResult = await currentAccounts.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await currentAccounts.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

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
