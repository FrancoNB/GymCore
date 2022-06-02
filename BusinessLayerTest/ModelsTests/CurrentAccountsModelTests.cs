using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
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
    public class CurrentAccountsModelTests
    {
        private Mock<ICurrentAccountsRepository> mockCurrentAccountsRepository;
        private CurrentAccountsModel currentAccountsModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mockCurrentAccountsRepository = new Mock<ICurrentAccountsRepository>();

            mockCurrentAccountsRepository.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<CurrentAccounts>>(new List<CurrentAccounts>()));
            mockCurrentAccountsRepository.Setup(x => x.Insert(It.IsAny<CurrentAccounts>())).Returns(Task.FromResult(1));
            mockCurrentAccountsRepository.Setup(x => x.Delete(It.Is<int>(id => id > 0))).Returns(Task.FromResult(1));
            mockCurrentAccountsRepository.Setup(x => x.Update(It.Is<CurrentAccounts>(client => client.IdClients > 0))).Returns(Task.FromResult(1));
        }

        [TestMethod()]
        public async Task GetAll_Test()
        {
            currentAccountsModel = new CurrentAccountsModel(mockCurrentAccountsModel.Object);

            CollectionAssert.AreEqual(new List<CurrentAccountsModel>(), (List<CurrentAccountsModel>)await currentAccountsModel.GetAll());
        }

        [TestMethod]
        public async Task SaveChanges_ValidInsertTest()
        {
            currentAccountsModel = new CurrentAccounts(mockCurrentAccountsRepository.Object)
            {
                Operation = BussinesLayer.ValueObjetcs.Operation.Insert(),
                IdCurrentAccounts = 1,
                IdClients = 1,
                TicketCode = "1234",
                Debit = 1234,
                Credit = 1234,
                Balance = 1234,
                Date = DateTime.UtcNow,
                Detail = "DetailTest"
            };

            Assert.IsTrue(await currentAccountsModel.SaveChangesAsync());
        }


    }
}
