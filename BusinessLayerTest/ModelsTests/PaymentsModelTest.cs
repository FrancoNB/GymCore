using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
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
    public class PaymentsModelTest
    {
        private Mock<IPaymentsRepository> mockPaymentsRepository;
        private PaymentsModel paymentsModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockPaymentsRepository = new Mock<IPaymentsRepository>();

            mockPaymentsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Payments>>(new List<Payments>()));
            mockPaymentsRepository.Setup(x => x.Insert(It.IsAny<Payments>())).Returns(Task.FromResult(1));
            mockPaymentsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockPaymentsRepository.Setup(x => x.Update(It.Is<Payments>(payment => payment.IdPayments > 0))).Returns(Task.FromResult(1));

            paymentsModel = new PaymentsModel(mockPaymentsRepository.Object)
            {
                IdPayments = 1,
                IdClients = 1,
                IdCurrentAccounts = 1,
                TicketCode = Tickets.Create("TestTicket", 1),
                Date = DateTime.Now,
                PaymentMethod = PaymentsModel.PaymentMethods.DebitCard,
                Amount = 123,
                Observations = "TestObservations"
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<PaymentsModel>(), (List<PaymentsModel>)await paymentsModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            paymentsModel.Operation = Operation.Insert;

            Assert.IsTrue((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            paymentsModel.Operation = Operation.Insert;
            paymentsModel.TicketCode = null;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            paymentsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            paymentsModel.Amount = -5;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()
        {
            paymentsModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            paymentsModel.IdClients = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_4()
        {
            paymentsModel.Operation = Operation.Insert;
            paymentsModel.IdCurrentAccounts = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.Observations = "NewObservations";

            Assert.IsTrue((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.TicketCode = null;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.Amount = -5;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.IdClients = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.IdCurrentAccounts = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_5()
        {
            paymentsModel.Operation = Operation.Update;
            paymentsModel.IdPayments = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            paymentsModel.Operation = Operation.Delete;

            Assert.IsTrue((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            paymentsModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            paymentsModel.IdPayments = 0;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            paymentsModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await paymentsModel.SaveChanges()).Result);
        }
    }
}
