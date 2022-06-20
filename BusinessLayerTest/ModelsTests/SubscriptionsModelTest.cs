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
    public class SubscriptionsModelTest
    {
        private Mock<ISubscriptionsRepository> mockSubscriptionsRepository;
        private SubscriptionsModel subscriptionsModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockSubscriptionsRepository = new Mock<ISubscriptionsRepository>();

            mockSubscriptionsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Subscriptions>>(new List<Subscriptions>()));
            mockSubscriptionsRepository.Setup(x => x.Insert(It.IsAny<Subscriptions>())).Returns(Task.FromResult(1));
            mockSubscriptionsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockSubscriptionsRepository.Setup(x => x.Update(It.Is<Subscriptions>(subscription => subscription.IdSubscriptions > 0))).Returns(Task.FromResult(1));

            subscriptionsModel = new SubscriptionsModel(mockSubscriptionsRepository.Object)
            {
                IdSubscriptions = 1,
                TicketCode = Tickets.Create("Test", 1),
                StartDate = DateTime.Now,
                Package = "TestPackage",
                Price = 1234,
                TotalSessions = 5,
                UsedSessions = 1,
                AvailableSessions = 4,
                EndDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                Observations = "ObservationTest",
                State = SubscriptionsModel.SubscriptionsStates.Active,
                IdClients = 1,
                IdCurrentAccounts = 1
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<SubscriptionsModel>(), (List<SubscriptionsModel>)await subscriptionsModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            subscriptionsModel.Operation = Operation.Insert;

            Assert.IsTrue((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            subscriptionsModel.Operation = Operation.Insert;
            subscriptionsModel.IdClients = 0;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            subscriptionsModel.Operation = Operation.Insert;
            subscriptionsModel.TicketCode = null;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()
        {
            subscriptionsModel.Operation = Operation.Insert;
            subscriptionsModel.Package = null;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_5()
        {
            subscriptionsModel.Operation = Operation.Insert;
            subscriptionsModel.TotalSessions = 0;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_6()
        {
            subscriptionsModel.Operation = Operation.Insert;
            subscriptionsModel.Price = 0;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            subscriptionsModel.Operation = Operation.Update;

            Assert.IsTrue((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInvalidateTest()
        {
            subscriptionsModel.Operation = Operation.Invalidate;

            Assert.IsTrue((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInvalidateTest_1()
        {
            subscriptionsModel.Operation = Operation.Invalidate;
            subscriptionsModel.IdSubscriptions = 0;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            subscriptionsModel.Operation = Operation.Delete;

            Assert.IsTrue((await subscriptionsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest_1()
        {
            subscriptionsModel.Operation = Operation.Delete;
            subscriptionsModel.IdSubscriptions = 0;

            Assert.IsFalse((await subscriptionsModel.SaveChanges()).Result);
        }
    }
}
