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
    public class WorkPlansIntegration
    {
        private WorkPlansModel workPlans;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            workPlans = new WorkPlansModel()
            {
                Name = "TestName",
                Category = "TestCategory"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            workPlans.Operation = Operation.Insert;

            AcctionResult acctionResult = await workPlans.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            workPlans.Operation = Operation.Update;

            AcctionResult acctionResult = await workPlans.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            workPlans.Operation = Operation.Delete;

            AcctionResult acctionResult = await workPlans.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await workPlans.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            workPlans.IdWorkPlans = await workPlans.GetLastId();

            Assert.IsTrue(workPlans.IdWorkPlans > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}