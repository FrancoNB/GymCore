using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Payments
{
    public class PaymentsDeleteService : IServiceStrategy<PaymentsModel>
    {
        private readonly CurrentAccountsModel currentAccountModel;

        public PaymentsDeleteService()
        {
            this.currentAccountModel = new CurrentAccountsModel();
        }

        public async Task<AcctionResult> SaveChanges(PaymentsModel paymentModel)
        {
            paymentModel.Operation = Operation.Delete;

            currentAccountModel.Operation = Operation.Delete;
            currentAccountModel.IdCurrentAccounts = paymentModel.IdCurrentAccounts;

            RepositoryConnection.BeginTransaction();

            try
            {
                AcctionResult action = await paymentModel.SaveChanges();

                if (action.Result)
                {
                    action = await currentAccountModel.SaveChanges();

                    if (action.Result)
                    {
                        RepositoryConnection.Commit();

                        return action;
                    }
                }

                RepositoryConnection.RollBack();

                return new AcctionResult(false, action.Message);
            }
            catch (Exception ex)
            {
                RepositoryConnection.RollBack();

                throw ex;
            }
        }
    }
}
