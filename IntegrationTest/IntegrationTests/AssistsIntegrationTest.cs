using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class AssistsIntegrationTest
    {
        private AssistsModel assists;

        private static int idClient;
        private static int idCurrentAccount;
        private static int idSubscription;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            IClientsRepository clientsRepository = new ClientsRepository();

            await clientsRepository.Insert(new Clients
            {
                Name = "AuxClient",
                Surname = "AuxClient",
                Address = "-",
                Phone = "-",
                Locality = "-",
                Mail = "-",
                RegisterDate = DateTime.Now,
                Observations = "-"
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

            idSubscription = await subscriptionsRepository.GetLastId();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            assists = new AssistsModel()
            {
                IdClients = idClient,
                IdSubscriptions = idSubscription,
                Date = DateTime.Now           
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            assists.Operation = Operation.Insert;

            AcctionResult acctionResult = await assists.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            assists.Operation = Operation.Update;

            AcctionResult acctionResult = await assists.SaveChanges();

            Assert.IsFalse(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            assists.Operation = Operation.Delete;

            AcctionResult acctionResult = await assists.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await assists.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            assists.IdAssists = await assists.GetLastId();

            Assert.IsTrue(assists.IdAssists > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}