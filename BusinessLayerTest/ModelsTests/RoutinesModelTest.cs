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
    public class RoutinesModelTest
    {
        private Mock<IRoutinesRepository> mockRoutinesRepository;
        private RoutinesModel routinesModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRoutinesRepository = new Mock<IRoutinesRepository>();

            mockRoutinesRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Routines>>(new List<Routines>()));
            mockRoutinesRepository.Setup(x => x.Insert(It.IsAny<Routines>())).Returns(Task.FromResult(1));
            mockRoutinesRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockRoutinesRepository.Setup(x => x.Update(It.Is<Routines>(client => client.IdRoutine > 0))).Returns(Task.FromResult(1));
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object);

            CollectionAssert.AreEqual(new List<RoutinesModel>(), (List<RoutinesModel>)await routinesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = 1,
                IdClients = 1, 
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()   //IdWorkPlans inválido
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = -1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()   //IdClients inválido
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = 1,
                IdClients = -1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()   //State inválido
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_4()   //StartDate inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_5()   //EndDate inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = 1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()   //idRoutines inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = -1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()   //idWorkPlans inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = 1,
                IdWorkPlans = -1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()   //idClients inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = 1,
                IdWorkPlans = 1,
                IdClients = -1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()   //State inválido
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = 1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_5()   //StartDate inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = -1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                EndDate = System.DateTime.Today
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_6()   //EndDate inválida
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdRoutines = -1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
                IdRoutines = 1
            };

            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete
            };

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }
    }
}
