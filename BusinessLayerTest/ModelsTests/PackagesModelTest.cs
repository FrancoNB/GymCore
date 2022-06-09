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
    public class PackagesModelTest
    {
        private Mock<IPackagesRepository> mockPackagesRepository;
        private PackagesModel packagesModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockPackagesRepository = new Mock<IPackagesRepository>();

            mockPackagesRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Packages>>(new List<Packages>()));
            mockPackagesRepository.Setup(x => x.Insert(It.IsAny<Packages>())).Returns(Task.FromResult(1));
            mockPackagesRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockPackagesRepository.Setup(x => x.Update(It.Is<Packages>(client => client.IdPackages > 0))).Returns(Task.FromResult(1));

            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                IdPackages = 1,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<PackagesModel>(), (List<PackagesModel>)await packagesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()  //String "PackageName" inválido
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            packagesModel.Name = "";

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()  //Número "NumberSessions" inválido.
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            packagesModel.NumberSessions = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()  //Número "AvailableDays" inválido.
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;
            packagesModel.AvailableDays = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()  
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()  //String "PackageName" inválido
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            packagesModel.Name = "";

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()  //Número "NumberSessions" inválido.
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            packagesModel.NumberSessions = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()  //Número "AvailableDays" inválido.
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            packagesModel.AvailableDays = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()  //Número "idPackages" inválido.
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            packagesModel.IdPackages = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
            packagesModel.IdPackages = 0;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            packagesModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }
    }
}
