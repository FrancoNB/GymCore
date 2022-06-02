using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayerTest
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
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            entity = new Clients()
            {
                RegisterDate = DateTime.Now,
                Name = "Walter",        
                Surname = "Lopez",
                Locality = "Jesus Maria",
                Address = "Sarmiento 205",
                Phone = "649151616161",
                Mail = "asdadsada",
                Observations = "-"
            };

            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdClients = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdClients, typeof(int));
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Name = "Ricardo";
            entity.Surname = "Lavolpe";

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdClients));
        }

        [TestMethod]
        public async Task Insert_InvalidTest()
        {
            entity = new Clients()
            {
                RegisterDate = DateTime.Now,
                Locality = "Jesus Maria",
                Address = "Sarmiento 205",
                Phone = "649151616161",
                Mail = "asdadsada",
                Observations = "-"
            };

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.Name = null;
            entity.Surname = "Lavolpe";
            
            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_InvalidTest()
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            Assert.AreEqual(0, await repository.Delete(entity.IdClients));
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            CollectionAssert.AllItemsAreInstancesOfType((List<Clients>)await repository.GetAll(), typeof(Clients));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
