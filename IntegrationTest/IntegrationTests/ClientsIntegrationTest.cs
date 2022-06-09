using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class ClientsIntegrationTest
    {
        private ClientsModel clientsModel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            clientsModel = new ClientsModel() 
            {
                Name = "TestClientName",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "1234567891",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            clientsModel.Operation = Operation.Insert;

            AcctionResult acctionResult = await clientsModel.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            clientsModel.Operation = Operation.Update;

            await GetLastId_ValidTest();

            AcctionResult acctionResult = await clientsModel.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            clientsModel.Operation = Operation.Delete;

            await GetLastId_ValidTest();

            AcctionResult acctionResult = await clientsModel.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await clientsModel.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            clientsModel.IdClients = await clientsModel.GetLastId();

            Assert.IsTrue(clientsModel.IdClients > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
