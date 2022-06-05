using BusinessLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerTest.ModelsTests
{
    [TestClass]
    public class CurrentAccountsModelTest
    {
        private Mock<ICurrentAccountsRepository> mockCurrentAccountsRepository;
        private CurrentAccountsModel currentAccountsModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockCurrentAccountsRepository = new Mock<ICurrentAccountsRepository>();

            mockCurrentAccountsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<CurrentAccounts>>(new List<CurrentAccounts>()));
            mockCurrentAccountsRepository.Setup(x => x.Insert(It.IsAny<CurrentAccounts>())).Returns(Task.FromResult(1));
            mockCurrentAccountsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockCurrentAccountsRepository.Setup(x => x.Update(It.Is<CurrentAccounts>(client => client.IdClients > 0))).Returns(Task.FromResult(1));
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object);

            CollectionAssert.AreEqual(new List<CurrentAccountsModel>(), (List<CurrentAccountsModel>)await currentAccountsModel.GetAll());
        }

        [TestMethod]
        public async Task SaveChanges_ValidInsertTest()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdCurrentAccounts = 1,
                IdClients = 1,
                TicketCode = "1234",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdCurrentAccounts = 1,
                IdClients = 1,
                TicketCode = "",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdCurrentAccounts = 1,
                IdClients = 1,
                TicketCode = "1234",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdCurrentAccounts = -1,
                IdClients = 1,
                TicketCode = "1234",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdCurrentAccounts = 1,
                IdClients = -1,
                TicketCode = "1234",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdCurrentAccounts = -1,
                IdClients = 1,
                TicketCode = "",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidDeleteTest()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
                IdCurrentAccounts = 1
            };

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
            };

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }
    }
}
