using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
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

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            routines = new RoutinesModel()
            {
                IdWorkPlans = 1,
                IdClients = 1,
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