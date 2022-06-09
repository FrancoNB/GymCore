using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerTest.Repositories
{
    [TestClass]
    public class CurrentAccountsRepositoryTest
    {
        private ICurrentAccountsRepository repository;
        private CurrentAccounts entity;

        private static int idClient;

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
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new CurrentAccountsRepository();

            entity = new CurrentAccounts()
            {
                TicketCode = "TestTicket",
                Date = DateTime.Now,
                Credit = 1234,
                Debit = 1234,
                Detail = "DetailTest",
                IdClients = idClient
            };
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await repository.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1() //idCliente invalido
        {
            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2() //Campo TicketCode nulo
        {
            entity.TicketCode = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdCurrentAccounts = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdCurrentAccounts, typeof(int));
            Assert.IsTrue(entity.IdCurrentAccounts > 0);
        }

        [TestMethod]
        public async Task Update_ValidTest() //Modificacion del detalle
        {
            await GetLastId_ValidTest();

            entity.Detail = "NewDetail";
            entity.IdClients = idClient;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1() //registro inexistente IdCurrentAccounts = 0
        {
            entity.IdCurrentAccounts = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2() //idClients invalido
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3() //Campo Detail nulo
        {
            await GetLastId_ValidTest();

            entity.Detail = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdCurrentAccounts));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdCurrentAccounts = 0
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
