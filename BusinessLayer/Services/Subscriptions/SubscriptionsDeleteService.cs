using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public class SubscriptionsDeleteService : IServiceStrategy<SubscriptionsModel>
    {
        private readonly CurrentAccountsModel currentAccountModel;

        public SubscriptionsDeleteService()
        {
            this.currentAccountModel = new CurrentAccountsModel();
        }

        public async Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel)
        {
            subscriptionModel.Operation = Operation.Delete;

            currentAccountModel.Operation = Operation.Delete;
            currentAccountModel.IdCurrentAccounts = subscriptionModel.IdCurrentAccounts;

            RepositoryConnection.BeginTransaction();

            try
            {
                AcctionResult action = await subscriptionModel.SaveChanges();

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
