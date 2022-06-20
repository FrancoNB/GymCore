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
    public class ClientsRepositoryTest
    {
        private IClientsRepository repository;
        private Clients entity;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new ClientsRepository();

            entity = new Clients()
            {
                Name = "TestNameClient",
                Surname = "TestSurnameClient",
                RegisterDate = DateTime.Now,
                Locality = "TestLocality",
                Address = "TestAddress",
                Phone = "1234567891",
                Mail = "test@test.com",
                Observations = "-"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdClients = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdClients, typeof(int));
            Assert.IsTrue(entity.IdClients > 0);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Name = "NewName";
            entity.Surname = "NewSurname";

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdClients));
        }

        [TestMethod]
        public async Task Insert_InvalidTest() //Campo Address nulo
        {
            entity.Address = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_1() //Registro inexistente IdClients = 0
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2() //Campo Name nulo
        {
            await GetLastId_ValidTest();

            entity.Name = null;
            entity.Surname = "NewSurname";
            
            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //Registro inexistente IdClients = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
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
