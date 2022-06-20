using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerTest.Repositories
{
    [TestClass]
    public class AssistsRepositoryTest
    {
        private IAssistsRepository repository;
        private Assists entity;

        private static int idClient;
        private static int idCurrentAccount;
        private static int idSubscriptions;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            IClientsRepository clientsRepository = new ClientsRepository();

            await clientsRepository.Insert(new Clients
            {
                Name = "AuxClient",
                Surname = "AuxClient",
                Address = "AuxAddres",
                Phone = "AuxPhone",
                Locality = "AuxLocality",
                Mail = "AuxMail",
                RegisterDate = DateTime.Now,
                Observations = "AuxObservations"
            });

            idClient = await clientsRepository.GetLastId();

            ICurrentAccountsRepository currentAccountsRepository = new CurrentAccountsRepository();

            await currentAccountsRepository.Insert(new CurrentAccounts
            {
                IdClients = idClient,
                TicketCode = "AuxTicket",
                Date = DateTime.Now,
                Credit = 1,
                Debit = 1,
                Detail = "AuxDetail"
            });

            idCurrentAccount = await currentAccountsRepository.GetLastId();

            ISubscriptionsRepository subscriptionsRepository = new SubscriptionsRepository();

            await subscriptionsRepository.Insert(new Subscriptions
            {
                IdClients = idClient,
                IdCurrentAccounts = idCurrentAccount,
                TicketCode = "TestCode",
                StartDate = DateTime.Now,
                TotalSessions = 1,
                UsedSessions = 1,
                AvailableSessions = 1,
                Package = "AuxPrice",
                Price = 1,
                EndDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                Observations = "AuxObservation",
                State = "AuxState"
            });

            idSubscriptions = await subscriptionsRepository.GetLastId();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new AssistsRepository();

            entity = new Assists()
            {
                Date = DateTime.Now,
                IdClients = idClient,
                IdSubscriptions = idSubscriptions
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            entity.IdClients = idClient;

            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Date = new DateTime(26 / 06 / 2022);

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            entity.IdSubscriptions = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.IdSubscriptions = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3()
        {
            await GetLastId_ValidTest();

            entity.IdAssists = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdAssists));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdAssits = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdAssists = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdAssists, typeof(int));
            Assert.IsTrue(entity.IdAssists > 0);
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await repository.GetAll()).ToList().Count > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}