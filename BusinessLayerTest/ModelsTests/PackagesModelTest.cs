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
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object);

            CollectionAssert.AreEqual(new List<PackagesModel>(), (List<PackagesModel>)await packagesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()  //String "PackageName" inválido
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()  //Número "NumberSessions" inválido.
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestPackageName",
                NumberSessions = -1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_3()  //Número "AvailableDays" inválido.
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = -1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()  
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdPackages = 1,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()  //String "PackageName" inválido
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdPackages = 1,
                Name = "",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()  //Número "NumberSessions" inválido.
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdPackages = 1,
                Name = "TestPackageName",
                NumberSessions = -1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()  //Número "AvailableDays" inválido.
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdPackages = 1,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = -1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_4()  //Número "idPackages" inválido.
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Update,
                IdPackages = -2,
                Name = "TestPackageName",
                NumberSessions = 1,
                AvailableDays = 1,
                Price = 1234
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete,
                IdPackages = 1,
            };

            Assert.IsTrue((await packagesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            packagesModel = new PackagesModel(mockPackagesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Delete
            };

            Assert.IsFalse((await packagesModel.SaveChanges()).Result);
        }
    }
}
