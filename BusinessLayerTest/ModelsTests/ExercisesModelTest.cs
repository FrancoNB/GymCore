using BusinessLayer.Models;
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
    public class ExercisesModelTest
    {
        private Mock<IExercisesRepository> mockExercisesRepository;
        private ExercisesModel exercisesModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockExercisesRepository = new Mock<IExercisesRepository>();

            mockExercisesRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Exercises>>(new List<Exercises>()));
            mockExercisesRepository.Setup(x => x.Insert(It.IsAny<Exercises>())).Returns(Task.FromResult(1));
            mockExercisesRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockExercisesRepository.Setup(x => x.Update(It.Is<Exercises>(client => client.IdExercises > 0))).Returns(Task.FromResult(1));
        }


        [TestMethod()]
        public async Task GetAll_Test()
        {
            exercisesModel = new ExercisesModel(mockExercisesRepository.Object);

            CollectionAssert.AreEqual(new List<ExercisesModel>(), (List<ExercisesModel>)await exercisesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            exercisesModel = new ExercisesModel(mockExercisesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "TestExerciseName",
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

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_1() //Invalid Name
        {
            exercisesModel = new ExercisesModel(mockExercisesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "",
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

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }
       
        [TestMethod()]
        public async Task SaveChanges_InvalidInsertTest_2() //Invalid Hamstring
        {
            exercisesModel = new ExercisesModel(mockExercisesRepository.Object)
            {
                Operation = BusinessLayer.ValueObjects.Operation.Insert,
                Name = "NameTest",
                Detail = "DetailTest",
                HamstringPoints = -1,
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

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }
    }

}
