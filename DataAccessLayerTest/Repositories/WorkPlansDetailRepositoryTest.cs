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
    public class WorkPlansDetailRepositoryTest
    {
        private IWorkPlansDetailRepository repository;
        private WorkPlansDetail entity;

        private static int idWorkPlans;
        private static int idWorks;
        private static int idExercises;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();

            IWorkPlansRepository workPlansRepository = new WorkPlansRepository();

            await workPlansRepository.Insert(new WorkPlans
            {
                Name = "AuxName",
                Category = "AuxCategory"
            });

            idWorkPlans = await workPlansRepository.GetLastId();

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

            IWorksRepository worksRepository = new WorksRepository();

            await worksRepository.Insert(new Works
            {
                IdExercises = idExercises,
                Series = 1,
                Duration = 1,
                Repetitions = 1,
                RestTime = 1,
                Load = 1,
                Intensity = 1
            });

            idWorks = await worksRepository.GetLastId();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new WorkPlansDetailRepository();

            entity = new WorkPlansDetail()
            {
                Day = 1,
                IdWorkPlans = idWorkPlans,
                IdWorks = idWorks
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
            entity.IdWorkPlans = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Insert_InvalidTest_2()
        {
            entity.IdWorks = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            entity.Day = 2;

            Assert.AreEqual(1, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_1()
        {
            await GetLastId_ValidTest();

            entity.IdWorkPlansDetail = 0;

            Assert.AreEqual(0, await repository.Update(entity));
        }

        [TestMethod]
        public async Task Update_InvalidTest_2()
        {
            await GetLastId_ValidTest();

            entity.IdWorkPlans = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Update_InvalidTest_3()
        {
            await GetLastId_ValidTest();

            entity.IdWorks = 0;

            var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Update(entity));

            Assert.AreEqual(1452, ex.Code);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            Assert.AreEqual(1, await repository.Delete(entity.IdWorkPlansDetail));
        }

        [TestMethod]
        public async Task Delete_InvalidTest() //registro inexistente IdAssits = 0
        {
            Assert.AreEqual(0, await repository.Delete(0));
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            entity.IdWorkPlansDetail = await repository.GetLastId();

            Assert.IsInstanceOfType(entity.IdWorkPlansDetail, typeof(int));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}