using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestClass]
    public class ExercisesIntegrationTest
    {
        private ExercisesModel exercises;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            RepositoryConnection.BeginTransaction();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            exercises = new ExercisesModel()
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
                PectoralsPoints = 1
            };
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            exercises.Operation = Operation.Insert;

            AcctionResult acctionResult = await exercises.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Update_ValidTest()
        {
            await GetLastId_ValidTest();

            exercises.Operation = Operation.Update;

            AcctionResult acctionResult = await exercises.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task Delete_ValidTest()
        {
            await GetLastId_ValidTest();

            exercises.Operation = Operation.Delete;

            AcctionResult acctionResult = await exercises.SaveChanges();

            Assert.IsTrue(acctionResult.Result);
        }

        [TestMethod]
        public async Task GetAll_ValidTest()
        {
            await Insert_ValidTest();

            Assert.IsTrue((await exercises.GetAll()).ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetLastId_ValidTest()
        {
            await Insert_ValidTest();

            exercises.IdExercises = await exercises.GetLastId();

            Assert.IsTrue(exercises.IdExercises > 0);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RepositoryConnection.RollBack();
        }
    }
}
