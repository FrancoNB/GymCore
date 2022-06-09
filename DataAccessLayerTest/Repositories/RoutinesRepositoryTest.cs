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
    public class RoutinesRepositoryTest
    {
        private IRoutinesRepository repository;
        private Routines entity;

        private static int idClient;
        private static int idWorkPlans;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            IClientsRepository clientsRepository = new ClientsRepository();

            await clientsRepository.Insert(new Clients
            {
                Name = "AuxClient",
                Surname = "AuxClient",
                Address = "AuxAddress",
                Phone = "AuxPhone",
                Locality = "AuxLocality",
                Mail = "AuxMail",
                RegisterDate = DateTime.Now,
                Observations = "AuxObservations"
            });

            idClient = await clientsRepository.GetLastId();

            IWorkPlansRepository workPlansRepository = new WorkPlansRepository();

            await workPlansRepository.Insert(new WorkPlans
            {
                Name = "AuxName",
                Category = "AuxCategory"
            });

            idWorkPlans = await workPlansRepository.GetLastId(); 
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new RoutinesRepository();

            entity = new Routines()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                State = "TestState",
                IdClients = idClient,
                IdWorkPlans = idWorkPlans
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
        public async Task Insert_InvalidTest_1()
        {
            entity.State = null;

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
            entity.IdWorkPlans = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.State = "UpdateStateTest";

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            entity.IdRoutines = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.State = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3()
        {
            await GetLastId_ValidTest();

            entity.IdWorkPlans = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_4()
        {
            await GetLastId_ValidTest();

            entity.IdClients = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdRoutines));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdPayments = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdRoutines = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdRoutines, typeof(int));
            Assert.IsTrue(entity.IdRoutines > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
