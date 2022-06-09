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
    public class RoutinesIntegrationTest
    {
        private RoutinesModel routines;

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
            routines = new RoutinesModel()
            {
                IdWorkPlans = idWorkPlans,
                IdClients = idClient,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            routines.Operation = Operation.Insert;

            AcctionResult acctionResult = await routines.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            routines.Operation = Operation.Update;

            AcctionResult acctionResult = await routines.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            routines.Operation = Operation.Delete;

            AcctionResult acctionResult = await routines.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await routines.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            routines.IdRoutines = await routines.GetLastId();

            Assert.IsTrue(routines.IdRoutines > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}