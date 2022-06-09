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
            mockRoutinesRepository.Setup(x => x.Update(It.Is<Routines>(client => client.IdRoutines > 0))).Returns(Task.FromResult(1));

            routinesModel = new RoutinesModel(mockRoutinesRepository.Object)
            {
                IdRoutines = 1,
                IdWorkPlans = 1,
                IdClients = 1,
                State = "Habilitado",
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<RoutinesModel>(), (List<RoutinesModel>)await routinesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()   //IdWorkPlans inválido
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            routinesModel.IdWorkPlans = 0;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()   //IdClients inválido
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            routinesModel.IdClients = 0;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()   //State inválido
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            routinesModel.State = "";

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()   //idRoutines inválida
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            routinesModel.IdRoutines = 0;                                   

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()   //idWorkPlans inválida
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            routinesModel.IdWorkPlans = 0;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()   //idClients inválida
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            routinesModel.IdClients = 0;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()   //State inválido
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            routinesModel.State = "";

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;


            Assert.IsTrue((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            routinesModel.IdRoutines = 0;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            routinesModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await routinesModel.SaveChanges()).Result);
        }
    }
}
