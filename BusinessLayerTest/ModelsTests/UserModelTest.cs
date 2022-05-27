using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayerTest
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
        }

        [TestMethod()]
        public async Task LogIn_ValidTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Username = "UserValid",
                Password = "PasswordValid"
            };

            Assert.IsTrue((await usersModel.LogIn()).Result);
            
        }

        [TestMethod()]
        public async Task LogIn_InvalidTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Username = "UserInvalid",
                Password = "PasswordInvalid"
            };

            Assert.IsFalse((await usersModel.LogIn()).Result);
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            usersModel = new UsersModel(mockUsersRepository.Object);

            CollectionAssert.AreEqual(new List<UsersModel>(), (List<UsersModel>)await usersModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Insert,
                Username = "TestUser",
                Password = "*****",
                Type = "-",
                State = "Habilitado"
            };

            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Insert,
                Username = "",
                Password = "*****",
                Type = "-",
                State = "Habilitado"
            };

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidUpdateTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Update,
                IdUsers = 1,
                Username = "UpdateTestUser",
                Password = "*****",
                Type = "-",
                State = "Habilitado"
            };

            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidUpdateTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Update,
                IdUsers = 1,
                Username = "UpdateTestUser",
                Password = "",
                Type = "-",
                State = "Habilitado"
            };

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_ValidDeleteTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Delete,
                IdUsers = 1
            };

            Assert.IsTrue((await usersModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            usersModel = new UsersModel(mockUsersRepository.Object)
            {
                Operation = Operation.Delete
            };

            Assert.IsFalse((await usersModel.SaveChanges()).Result);
        }
    }
}
