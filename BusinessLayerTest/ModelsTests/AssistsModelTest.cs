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
    public class AssistsModelTest
    {
        private Mock<IAssistsRepository> mockAssistsRepository;
        private AssistsModel assistsModel;

        [TestInitialize]
        public void TestInitialize()
        {

            mockAssistsRepository = new Mock<IAssistsRepository>();

            mockAssistsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Assists>>(new List<Assists>()));
            mockAssistsRepository.Setup(x => x.Insert(It.IsAny<Assists>())).Returns(Task.FromResult(1));
            mockAssistsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockAssistsRepository.Setup(x => x.Update(It.Is<Assists>(client => client.IdAssists > 0))).Returns(Task.FromResult(1));

            assistsModel = new AssistsModel(mockAssistsRepository.Object)
            {
                IdAssists = 1,
                Date = DateTime.Now,
                IdClients = 1,
                IdSubscriptions = 1,
            };
        }
        
        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<AssistsModel>(), (List<AssistsModel>)await assistsModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            assistsModel.Operation = Operation.Insert;

            Assert.IsTrue((await assistsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()  
        {
            assistsModel.Operation = Operation.Insert;
            assistsModel.IdClients= 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            assistsModel.Operation = Operation.Insert;
            assistsModel.IdSubscriptions = 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }

        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            assistsModel.Operation = Operation.Update;
            assistsModel.IdClients = 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            assistsModel.Operation = Operation.Update;
            assistsModel.IdSubscriptions = 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }

        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            assistsModel.Operation = Operation.Update;
            assistsModel.IdAssists = 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            assistsModel.Operation = Operation.Delete;

            Assert.IsTrue((await assistsModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            assistsModel.Operation = Operation.Delete;
            assistsModel.IdAssists = 0;

            Assert.IsFalse((await assistsModel.SaveChanges()).Result);
        }
    }
}
