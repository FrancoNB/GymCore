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
            CollectionAssert.AllItemsAreInstancesOfType((List<Routines>)await repository.GetAll(), typeof(Routines));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

       // [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Update(entity));
        }

        //[TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdRoutine = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdRoutine, typeof(int));
            Assert.IsTrue(entity.IdRoutine > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
