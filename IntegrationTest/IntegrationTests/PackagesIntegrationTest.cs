using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class PackagesIntegrationTest
    {
        private PackagesModel packages;
        private static Random random;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            random = new Random();  
        }

        [TestInitialize]
        public void TestInitialize()
        {
            packages = new PackagesModel()
            {
                Name = "TestPackageName" + random.Next().ToString(),
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            packages.Operation = Operation.Insert;

            AcctionResult acctionResult = await packages.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            packages.Operation = Operation.Update;

            AcctionResult acctionResult = await packages.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            packages.Operation = Operation.Delete;

            AcctionResult acctionResult = await packages.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await packages.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            packages.IdPackages = await packages.GetLastId();

            Assert.IsTrue(packages.IdPackages > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
