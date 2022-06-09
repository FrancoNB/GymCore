using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
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
    public class PackagesRepositoryTest
    {
        private IPackagesRepository repository;
        private Packages entity;

        private static Random random;

        [ClassInitialize]
        public static void ClassInitializate(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            random = new Random();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new PackagesRepository();

            entity = new Packages()
            {
                Name = "NameTest" + random.Next().ToString(),
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
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

            entity.IdPackages = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdPackages, typeof(int));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1,await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity.Name = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            Assert.AreEqual(1, await repository.Insert(entity));

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1062, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Price = 4321;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            entity.IdPackages = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.Name = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdPackages));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdPackages = 0
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