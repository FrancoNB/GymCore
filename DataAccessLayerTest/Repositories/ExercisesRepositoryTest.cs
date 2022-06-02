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
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            CollectionAssert.AllItemsAreInstancesOfType((List<Exercises>)await repository.GetAll(), typeof(Exercises));
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            entity = new Exercises()
            {
                Name = "NameTest",
                Detail = "DetailTest",
                HamstringPoints = 1,
                QuadricepsPoints = 1,
                CalvesPoints = 1,
                ButtocksPoints = 1,
                TrapeziusPoints = 1,
                DorsalPoints = 1,
                AbdominalPoints = 1,
                ObliquesPoints = 1,
                BicepsPoints = 1,
                TricepsPoints = 1,
                ForeArmPoints = 1,
                PosteriorDeltoidPoints = 1,
                LateralDeltoidPoints = 1,
                AnteriorDeltoidPoints = 1,
                AdductorPoints = 1,
                LumbarPoints = 1,
                PectoralPoints = 1,
            };

            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Name = "NameTest";
            entity.Detail = "DetailTest";
            entity.HamstringPoints = 1;
            entity.QuadricepsPoints = 1;
            entity.CalvesPoints = 1;
            entity.ButtocksPoints = 1;
            entity.TrapeziusPoints = 1;
            entity.DorsalPoints = 1;
            entity.AbdominalPoints = 1;
            entity.ObliquesPoints = 1;
            entity.BicepsPoints = 1;
            entity.TricepsPoints = 1;
            entity.ForeArmPoints = 1;
            entity.PosteriorDeltoidPoints = 1;
            entity.LateralDeltoidPoints = 1;
            entity.AnteriorDeltoidPoints = 1;
            entity.AdductorPoints = 1;
            entity.LumbarPoints = 1;
            entity.PectoralPoints = 1;

            Assert.AreEqual(1, await repository.Update(entity));
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
