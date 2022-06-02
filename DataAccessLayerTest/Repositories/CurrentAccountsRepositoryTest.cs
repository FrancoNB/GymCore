using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerTest.Repositories
{
    [TestClass]
    public class CurrentAccountsRepositoryTest
    {
        private ICurrentAccountsRepository repository;
        private CurrentAccounts entity;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();


        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new CurrentAccountsRepository();
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            CollectionAssert.AllItemsAreInstancesOfType((List<CurrentAccounts>)await repository.GetAll(), typeof(CurrentAccounts));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            entity = new CurrentAccounts()
            {
                TicketCode = "1234",
                Date = DateTime.Now,
                Credit = 1234,
                Debit = 1234,
                Balance = 1234,
                Detail = "DetailTest",
                IdClients = 1
            };

            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity = new CurrentAccounts()
            {
                TicketCode = "",
                Date = DateTime.Now,
                Credit = 1234,
                Debit = 1234,
                Balance = 1234,
                Detail = "DetailTest",
                IdClients = 1
            };

            Assert.AreEqual(0, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdCurrentAccounts = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdCurrentAccounts, typeof(int));
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.IdCurrentAccounts = 1;
            entity.TicketCode = "1234";
            entity.Date = DateTime.Now;
            entity.Credit = 1234;
            entity.Debit = 1234;
            entity.Balance = 1234;
            entity.Detail = "DetailTest";
            entity.IdClients = 1;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdCurrentAccounts = -1;
            entity.TicketCode = "1234";
            entity.Date = DateTime.Now;
            entity.Credit = 1234;
            entity.Debit = 1234;
            entity.Balance = 1234;
            entity.Detail = "DetailTest";
            entity.IdClients = 1;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.IdCurrentAccounts = 1;
            entity.TicketCode = "1234";
            entity.Date = DateTime.Now;
            entity.Credit = 1234;
            entity.Debit = 1234;
            entity.Balance = 1234;
            entity.Detail = "DetailTest";
            entity.IdClients = -1;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_3()
        {
            await GetLastId_ValidTest();

            entity.IdCurrentAccounts = 1;
            entity.TicketCode = "";
            entity.Date = DateTime.Now;
            entity.Credit = 1234;
            entity.Debit = 1234;
            entity.Balance = 1234;
            entity.Detail = "DetailTest";
            entity.IdClients = 1;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdCurrentAccounts));
        }

        [TestMethod]
        public async Task Delete_InvalidTest()
        {
            await GetLastId_ValidTest();

            entity.IdCurrentAccounts = 0;

            Assert.AreEqual(0, await repository.Delete(entity.IdCurrentAccounts));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
