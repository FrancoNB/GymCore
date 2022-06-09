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

            workPlansModel = new WorkPlansModel(mockWorkPlansRepository.Object)
            {
                IdWorkPlans = 1,
                Name = "InserTestWorkPlanName",
                Category = "InserTestWorkPlanCategory"
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<WorkPlansModel>(), (List<WorkPlansModel>)await workPlansModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            workPlansModel.Name = "";

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            workPlansModel.Category = "";

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            workPlansModel.Name = "";

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            workPlansModel.Category = "";

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            workPlansModel.IdWorkPlans = 0;

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;

            Assert.IsTrue((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            workPlansModel.IdWorkPlans = 0;

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            workPlansModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await workPlansModel.SaveChanges()).Result);
        }
    }
}
