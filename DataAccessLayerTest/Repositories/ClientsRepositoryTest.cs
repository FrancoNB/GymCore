using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace DataAccessLayerTest
{
    [TestClass]
    public class ClientsRepositoryTest
    {
        private IClientsRepository repository;
        private Clients entity;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new ClientsRepository();
        }

        [TestMethod]
        public async Task Insert_ValidTest()
        {
            entity = new Clients()
            {
                RegisterDate = DateTime.Now,
                Name = "Walter",        
                Surname = "Lopez",
                Locality = "Jesus Maria",
                Address = "Sarmiento 205",
                Phone = "649151616161",
                Mail = "asdadsada",
                Observations = "-"
            };

            try
            {
                RepositoryConnection.BeginTransaction();

                Assert.AreEqual(1, await repository.Insert(entity));
            } 
            finally
            {
                RepositoryConnection.RollBack();
            }
        }

        [TestMethod]
        public async Task Insert_InvalidTest()
        {
            entity = new Clients()
            {
                RegisterDate = DateTime.Now,
                Locality = "Jesus Maria",
                Address = "Sarmiento 205",
                Phone = "649151616161",
                Mail = "asdadsada",
                Observations = "-"
            };

            try
            {
                RepositoryConnection.BeginTransaction();

                var ex = await Assert.ThrowsExceptionAsync<RepositoryException>(() => repository.Insert(entity));

                Assert.AreEqual(1048, ex.Code);
            }
            finally
            {
                RepositoryConnection.RollBack();
            }
        }
    }
}
