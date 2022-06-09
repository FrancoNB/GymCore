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

            exercisesModel = new ExercisesModel(mockExercisesRepository.Object)
            {
                Name = "TestExerciseName",
                Detail = "DetailTest",
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
                PectoralsPoints = 1,
            };

        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            CollectionAssert.AreEqual(new List<ExercisesModel>(), (List<ExercisesModel>)await exercisesModel.GetAll());
        }

        [TestMethod()]
        public async Task SaveChanges_ValidInsertTest()
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_1() //Invalid Name
        {

            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.Name = "";

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_2() //Invalid Hamstring
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.HamstringPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_3() //Invalid Quadriceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.QuadricepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }
        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_4() //Invalid Calves
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.CalvesPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_5() //Invalid Buttocks
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.ButtocksPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_6() //Invalid Trapezius
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.TrapeziusPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_7() //Invalid Dorsal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.DorsalsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_8() //Invalid Abdominal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.AbdominalsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_9() //Invalid Obliques
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.ObliquesPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_10() //Invalid Biceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.BicepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_11() //Invalid Triceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.TricepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_12() //Invalid Forearm
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.ForeArmPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_13() //Invalid Posterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.PosteriorDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_14() //Invalid Lateral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.LateralDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_15() //Invalid Anterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.AnteriorDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_16() //Invalid Adductor
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.AdductorPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_17() //Invalid Lumbar
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.LumbarsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidInsertTest_18() //Invalid Pectoral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Insert;

            exercisesModel.PectoralsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_1() //Update Valid Name
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.Name = "NameTest";

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_2() //Update Valid Hamstring
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.HamstringPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_3() //Update Valid Quadriceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.QuadricepsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_4() //Update Invalid Calves
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.CalvesPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_5() //Update Invalid Buttocks
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.ButtocksPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_6() //Update valid Trapezius
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.TrapeziusPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_7() //Update valid Dorsal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.DorsalsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_8() //Update valid Abdominal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.AbdominalsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_9() //Update valid Obliques
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.ObliquesPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_10() //Update Valid Biceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.BicepsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_11() //Update valid Triceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.TricepsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_12() //Update valid Forearm
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.ForeArmPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_13() //Update valid Posterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.PosteriorDeltoidPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_14() //Update Valid Lateral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            
            exercisesModel.IdExercises = 1;

            exercisesModel.LateralDeltoidPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_15() //Update valid Anterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;
            
            exercisesModel.IdExercises = 1;
           
            exercisesModel.AnteriorDeltoidPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_16() //Update valid Adductor
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.AdductorPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_17() //Update valid Lumbar
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.LumbarsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_ValidUpdateTest_18() //Update valid Pectoral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.IdExercises = 1;

            exercisesModel.PectoralsPoints = 10;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_1() //Update Invalid Name
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.Name = "";

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_2() //Update Invalid Hamstring
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.HamstringPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_3() //Update Invalid Quadriceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.QuadricepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_4() //Update Invalid Calves
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.CalvesPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_5() //Update Invalid Buttocks
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.ButtocksPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_6() //Update Invalid Trapezius
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.TrapeziusPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_7() //Update Invalid Dorsal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.DorsalsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_8() //Update Invalid Abdominal
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.AbdominalsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_9() //Update Invalid Obliques
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.ObliquesPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_10() //Update Invalid Biceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.BicepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_11() //Update Invalid Triceps
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.TricepsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_12() //Update Invalid Forearm
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.ForeArmPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_13() //Update Invalid Posterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.PosteriorDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_14() //Update Invalid Lateral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.LateralDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_15() //Update Invalid Anterior
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.AnteriorDeltoidPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_16() //Update Invalid Adductor
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.AdductorPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_17() //Update Invalid Lumbar
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.LumbarsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }


        [TestMethod]
        public async Task SaveChanges_InvalidUpdateTest_18() //Update Invalid Pectoral
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Update;

            exercisesModel.PectoralsPoints = -1;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_ValidDeleteTest()
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;
           
            exercisesModel.IdExercises = 1;

            Assert.IsTrue((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod]
        public async Task SaveChanges_InvalidDeleteTest()
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Delete;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }

        [TestMethod()]
        public async Task SaveChanges_InvalidOperationTest()
        {
            exercisesModel.Operation = BusinessLayer.ValueObjects.Operation.Invalidate;

            Assert.IsFalse((await exercisesModel.SaveChanges()).Result);
        }
    }

}
