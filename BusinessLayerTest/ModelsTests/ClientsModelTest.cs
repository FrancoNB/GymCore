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
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object);

            CollectionAssert.AreEqual(new List<ClientsModel>(), (List<ClientsModel>)await clientsModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestClientName",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "123456789",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "123456789",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestClientName",
                Surname = "",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "123456789",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestClientName",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "123456789",
                Mail = "InvalidTestClientMail",
                Observations = "TestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_4()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestClientName",
                Surname = "TestClientSurname",
                Locality = "TestClientLocality",
                Address = "TestClientAddress",
                Phone = "InvalidClientPhoneNumber",
                Mail = "TestClientMail@Email.com",
                Observations = "TestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "UpdateTestClientName",
                Surname = "UpdateTestClientSurname",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "123456789",
                Mail = "UpdateTestClientMail@Email.com",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "",
                Surname = "UpdateTestClientSurname",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "123456789",
                Mail = "UpdateTestClientMail@Email.com",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "UpdateTestClientNname",
                Surname = "",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "123456789",
                Mail = "UpdateTestClientMail@Email.com",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "UpdateTestClientName",
                Surname = "UpdateTestClientSurname",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "123456789",
                Mail = "UpdateTestClientMail@Email.com",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "UpdateTestClientName",
                Surname = "UpdateTestClientSurname",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "123456789",
                Mail = "InvalidUpdateTestClientMail",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_5()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdClients = 1,
                Name = "UpdateTestClientName",
                Surname = "UpdateTestClientSurname",
                Locality = "UpdateTestClientLocality",
                Address = "UpdateTestClientAddress",
                Phone = "InvalidClientPhoneNumber",
                Mail = "UpdateTestClientMail@Email.com",
                Observations = "UpdateTestClientObservations"
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
                IdClients = 1
            };

            Assert.IsTrue((await clientsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            clientsModel = new ClientsModel(mockClientsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete
            };

            Assert.IsFalse((await clientsModel.SaveChanges()).Result);
        }

    }
}
