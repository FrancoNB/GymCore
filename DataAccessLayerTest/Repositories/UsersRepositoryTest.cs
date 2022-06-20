using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerTest.Repositories
{
    [TestClass]
    public class UsersRepositoryTest
    {
        private IUsersRepository repository;
        private Users entity;

        private static Random random;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            random = new Random();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new UsersRepository();

            entity = new Users()
            {
                RegisterDate = DateTime.Now ,
                Type = "TypeTest",
                Username = "UsernameTest" + random.Next().ToString(),
                Password = "PasswordTest",
                LastConnection = DateTime.Now ,
            };
        }


        [TestMethod]
        public async Task GetAll_Test()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await repository.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetUser_Test()
        {
            await GetLastId_ValidTest();

            Users user = await repository.GetUser(entity.Username, entity.Password);

            Assert.IsTrue(user.IdUsers == entity.IdUsers);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdUsers = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdUsers, typeof(int));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity.Type = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            entity.Username = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_3()
        {
            entity.Password = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_4()
        {
            Assert.AreEqual(1, await repository.Insert(entity));

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1062, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Type = "UpdateTypeTest";

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1() //registro inexistente IdUsers
        {
            entity.IdUsers = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2() //registro inexistente Type
        {
            await GetLastId_ValidTest();

            entity.Type = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3() //registro inexistente Username
        {
            await GetLastId_ValidTest();

            entity.Username = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdUsers));
        }

        [TestMethod]
        public async Task Delete_InvalidTest()
        {
            await GetLastId_ValidTest();

            entity.IdUsers = 0;

            Assert.AreEqual(0, await repository.Delete(entity.IdUsers));
        }

        [TestMethod]
        public async Task UpdateLastConnection_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.UpdateLastConnection(DateTime.Now.AddHours(5), entity.IdUsers));
        }

        [TestMethod]
        public async Task UpdateLastConnection_InvalidTest()
        {
            Assert.AreEqual(0, await repository.UpdateLastConnection(DateTime.Now.AddHours(5), 0));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }

}

