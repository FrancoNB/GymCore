using BusinessLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayerTest.ModelsTests
{
    [TestClass]
    public class ClientsModelTest
    {
        private Mock<IClientsRepository> mockClientsRepository;
        private ClientsModel clientsModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockClientsRepository = new Mock<IClientsRepository>();

            mockClientsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Clients>>(new List<Clients>()));
            mockClientsRepository.Setup(x => x.Insert(It.IsAny<Clients>())).Returns(Task.FromResult(1));
            mockClientsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockClientsRepository.Setup(x => x.Update(It.Is<Clients>(client => client.IdClients > 0))).Returns(Task.FromResult(1));

            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                IdClients = 1,
                Name = "TestClientName",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "1234567891",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<ClientsModel>(), (List<ClientsModel>)await clientsModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            clientsModel.Name = "";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            clientsModel.Surname = "";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            clientsModel.Mail = "InvalidMailTest";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_4()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            clientsModel.Phone = "InvalidPhoneNumberTest";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            clientsModel.Name = "";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            clientsModel.Surname = "";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            clientsModel.Mail = "InvalidMailTest";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            clientsModel.Phone = "InvalidPhoneNumberTest";

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_5()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            clientsModel.IdClients = 0;

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            clientsModel.IdClients = 0;

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            clientsModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }
    }
}
