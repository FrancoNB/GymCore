using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
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
    public class UserModelTest
    {
        private Mock<IUsersRepository> mockUsersRepository;
        private UsersModel usersModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockUsersRepository = new Mock<IUsersRepository>();

            mockUsersRepository.Setup(x => x.GetUser("UserValid", "PasswordValid")).Returns(Task.FromResult(new Users()));
            mockUsersRepository.Setup(x => x.UpdateLastConnection(It.IsAny<DateTime>(), It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockUsersRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Users>>(new List<Users>()));
            mockUsersRepository.Setup(x => x.Insert(It.IsAny<Users>())).Returns(Task.FromResult(1));
            mockUsersRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockUsersRepository.Setup(x => x.Update(It.Is<Users>(user => user.IdUsers > 0))).Returns(Task.FromResult(1));

            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                IdUsers = 1,
                Username = "UserValid",
                Password = "PasswordValid"
            };
        }

        [TestMethod()]
        public async Task LogIn_ValidTest()
        {
            Assert.IsTrue((await usersModel.LogIn()).Result);        
        }

        [TestMethod()]
        public async Task LogIn_InvalidTest_1()
        {
            usersModel.Username = "UserInvalid";
            usersModel.Password = "PasswordValid";

            Assert.IsFalse((await usersModel.LogIn()).Result);
        }

        [TestMethod()]
        public async Task LogIn_InvalidTest_2()
        {

            usersModel.Username = "UserValid";
            usersModel.Password = "PasswordInvalid";

            Assert.IsFalse((await usersModel.LogIn()).Result);
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<UsersModel>(), (List<UsersModel>)await usersModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            usersModel.Operation = Operation.Insert;

            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1()
        {
            usersModel.Operation = Operation.Insert;
            usersModel.Username = "";

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2()
        {
            usersModel.Operation = Operation.Insert;
            usersModel.Password = "";

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            usersModel.Operation = Operation.Update;
            usersModel.Username = "NewUser";


            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_1()
        {
            usersModel.Operation = Operation.Update;
            usersModel.Username = "";

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_2()
        {
            usersModel.Operation = Operation.Update;
            usersModel.Password = "";

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest_3()
        {
            usersModel.Operation = Operation.Update;
            usersModel.IdUsers = 0;

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            usersModel.Operation = Operation.Delete;

            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            usersModel.Operation = Operation.Delete;
            usersModel.IdUsers = 0;

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            usersModel.Operation = Operation.Invalidate;

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }
    }
}
