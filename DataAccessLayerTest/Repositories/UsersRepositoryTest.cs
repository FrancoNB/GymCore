﻿using DataAccessLayer.Entities;
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

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new UsersRepository();

            entity = new Users()
            {
                RegisterDate = DateTime.Now ,
                Type = "TypeTest",
                Username = "UsernameTest",
                Password = "PasswordTest",
                LastConnection = DateTime.Now ,
            };
        }


        [TestMethod]
        public async Task GetAll_Test()
        {
            CollectionAssert.AllItemsAreInstancesOfType((List<Users>)await repository.GetAll(), typeof(Users));
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

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }

}

