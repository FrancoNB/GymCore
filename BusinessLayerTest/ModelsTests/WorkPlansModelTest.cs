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
    public class WorkPlansModelTest
    {
        private Mock<IWorkPlansRepository> mockWorkPlansRepository;
        private WorkPlansModel workPlansModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockWorkPlansRepository = new Mock<IWorkPlansRepository>();

            mockWorkPlansRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<WorkPlans>>(new List<WorkPlans>()));
            mockWorkPlansRepository.Setup(x => x.Insert(It.IsAny<WorkPlans>())).Returns(Task.FromResult(1));
            mockWorkPlansRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockWorkPlansRepository.Setup(x => x.Update(It.Is<WorkPlans>(client => client.IdWorkPlans > 0))).Returns(Task.FromResult(1));
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object);

            CollectionAssert.AreEqual(new List<WorkPlansModel>(), (List<WorkPlansModel>)await workPlansModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "InserTestWorkPlanName",
                Category = "InserTestWorkPlanCategory"
            };

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "",
                Category = "InserTestWorkPlanCategory"
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "InserTestWorkPlanName",
                Category = ""
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdWorkPlans = 1,
                Name = "InserTestWorkPlanName",
                Category = "InserTestWorkPlanCategory"
            };

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdWorkPlans = 1,
                Name = "",
                Category = "InserTestWorkPlanCategory"
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdWorkPlans = 1,
                Name = "InserTestWorkPlanName",
                Category = ""
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdWorkPlans = -1,
                Name = "InserTestWorkPlanName",
                Category = "InserTestWorkPlanCategory"
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
                IdWorkPlans = 1
            };

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete
            };

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }
    }
}
