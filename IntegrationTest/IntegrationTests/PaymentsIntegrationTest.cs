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
    public class PaymentsIntegrationTest
    {
        private PaymentsModel payments;

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
        }

        [TestInitialize]
        public void TestInitialize()
        {
            payments = new PaymentsModel()
            {
                IdClients = idClient,
                IdCurrentAccounts = idCurrentAccount,
                TicketCode = Tickets.Create("SUB", 1),
                Date = DateTime.Now,
                PaymentMethod = PaymentsModel.PaymentMethods.CreditCard,
                Amount = 123,
                Observations = "ObservationsTest"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            payments.Operation = Operation.Insert;

            AcctionResult acctionResult = await payments.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            payments.Operation = Operation.Update;

            AcctionResult acctionResult = await payments.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            payments.Operation = Operation.Delete;

            AcctionResult acctionResult = await payments.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await payments.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            payments.IdPayments = await payments.GetLastId();

            Assert.IsTrue(payments.IdPayments > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
