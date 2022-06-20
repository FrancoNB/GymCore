using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class SubscriptionsIntegrationTest
    {
        private SubscriptionsModel subscriptions;
        private static int idClient;
        private static int idCurrentAccount;

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
                Balance = 1,
                Detail = "AuxDetail"
            });

            idCurrentAccount = await currentAccountsRepository.GetLastId();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            subscriptions = new SubscriptionsModel()
            {
                TicketCode = Tickets.Create("Test", 1),
                StartDate = DateTime.Now,
                Package = "TestPackage",
                Price = 1234,
                TotalSessions = 5,
                UsedSessions = 1,
                AvailableSessions = 4,
                EndDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                Observations = "ObservationTest",
                State = SubscriptionsModel.SubscriptionsStates.Active,
                IdClients = idClient,
                IdCurrentAccounts = idCurrentAccount
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            subscriptions.Operation = Operation.Insert;

            AcctionResult acctionResult = await subscriptions.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            subscriptions.Operation = Operation.Update;

            subscriptions.EndDate = DateTime.Now;

            AcctionResult acctionResult = await subscriptions.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Invalidate_ValidTest()
        {
            await GetLastId_ValidTest();

            subscriptions.Operation = Operation.Invalidate;

            AcctionResult acctionResult = await subscriptions.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            subscriptions.Operation = Operation.Delete;

            AcctionResult acctionResult = await subscriptions.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await subscriptions.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            subscriptions.IdSubscriptions = await subscriptions.GetLastId();

            Assert.IsTrue(subscriptions.IdSubscriptions > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}