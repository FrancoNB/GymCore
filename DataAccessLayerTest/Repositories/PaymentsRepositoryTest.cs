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
    public class PaymentsRepositoryTest
    {
        private IPaymentsRepository repository;
        private Payments entity;
        private static int idClient;
        private static int idCurrentAccount;

        [ClassInitialize]
        public static async Task ClassInitializate(TestContext context)
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

        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new PaymentsRepository();

            entity = new Payments()
            {
                TicketCode = "TicketCodeTest",
                Date = DateTime.Now,
                Amount = 1.0,
                IdClients = idClient,
                IdCurrentAccounts = idCurrentAccount,
                PaymentMethod = "PaymentMethodTest",
                Observations = "ObservationsTest"
            };
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await repository.GetAll()).ToList().Count > 0);
        }


        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdPayments = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdPayments, typeof(int));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity.TicketCode = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_3()
        {
            entity.IdCurrentAccounts = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Amount = 4321.90;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdPayments = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.TicketCode = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdPayments));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdPayments = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }

    }
}
