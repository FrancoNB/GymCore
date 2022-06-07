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
    public class WorksRepositoryTest
    {
        private IWorksRepository repository;
        private Works entity;

        private static int idExercises;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            IExercisesRepository exercisesRepository = new ExercisesRepository();

            await exercisesRepository.Insert(new Exercises
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
            });

            idExercises = await exercisesRepository.GetLastId();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new WorksRepository();

            entity = new Works()
            {
                Series = 1,
                Duration = 1,
                Repetitions = 1,  
                RestTime = 1,
                Load = 1,
                Intensity = 1,
                IdExercises = idExercises,
            };
        }

        [TestMethod]
        public async Task GetAll_Test()
        {
            CollectionAssert.AllItemsAreInstancesOfType((List<Works>)await repository.GetAll(), typeof(Works));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdWorks = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdWorks, typeof(int));
        }


        [TestMethod]
        public async Task Insert_ValidTest()
        {
            Assert.AreEqual(1, await repository.Insert(entity));
        }

        [TestMethod]
        public async Task Insert_InvalidTest()
        {
            entity.IdExercises = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Series = 2;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdExercises = 0;
           
            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdWorks));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdWorks = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }

    }
}
