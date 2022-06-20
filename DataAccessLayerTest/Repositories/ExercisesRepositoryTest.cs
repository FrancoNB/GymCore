using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
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
    public class ExercisesRepositoryTest
    {
        private IExercisesRepository repository;
        private Exercises entity;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new ExercisesRepository();

            entity = new Exercises()
            {
                Name = "AuxExercise",
                Detail = "AuxExercise",
                HamstringPoints = 1,
                QuadricepsPoints = 1,
                CalvesPoints = 1,
                ButtocksPoints = 1,
                TrapeziusPoints = 1,
                DorsalsPoints = 1,
                AbdominalsPoints = 1,
                ObliquesPoints = 1,
                BicepsPoints = 1,
                TricepsPoints = 1,
                ForeArmPoints = 1,
                PosteriorDeltoidPoints = 1,
                LateralDeltoidPoints = 1,
                AnteriorDeltoidPoints = 1,
                AdductorPoints = 1,
                LumbarsPoints = 1,
                PectoralsPoints = 1
            };
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await repository.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest_1()
        {
            entity.Name = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            entity.Detail = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest() //Modificacion del detalle
        {
            await GetLastId_ValidTest();

            entity.Detail = "NewDetail";

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1() //registro inexistente IdCurrentAccounts = 0
        {
            entity.IdExercises = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2() 
        {
            await GetLastId_ValidTest();

            entity.Detail = null;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1048, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdExercises));
        }

        [TestMethod]
        public async Task Delete_InvalidTest()
        {
            entity.IdExercises = 0;

            Assert.AreEqual(0, await repository.Delete(entity.IdExercises));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdExercises = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdExercises, typeof(int));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
