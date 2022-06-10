using BusinessLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
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

            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsRepository.Object)
            {
                IdCurrentAccounts = 1,
                IdClients = 1,
                TicketCode = BusinessLayer.ValueObjects.Tickets.Create("SUB", 1),
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<CurrentAccountsModel>(), (List<CurrentAccountsModel>)await currentAccountsModel.GetAll());
        }

        [TestMethod]
        public async Task SaveChanges_ValidInsertTest()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            currentAccountsModel.TicketCode = null;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            currentAccountsModel.IdClients = 0;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_3()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            currentAccountsModel.Credit = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_4()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            currentAccountsModel.Debit = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            currentAccountsModel.IdCurrentAccounts = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            currentAccountsModel.IdClients = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            currentAccountsModel.TicketCode = null;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_4()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            currentAccountsModel.Credit = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_5()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            currentAccountsModel.Debit = -1;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidDeleteTest()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;

            Assert.IsTrue((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            currentAccountsModel.IdCurrentAccounts = 0; 

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            currentAccountsModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await currentAccountsModel.SaveChanges()).Result);
        }
    }
}
