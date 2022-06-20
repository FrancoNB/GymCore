using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Assists
{
    public class AssistsDeleteService : IServiceStrategy<AssistsModel>
    {
        private SubscriptionsModel subscriptionModel;

        public AssistsDeleteService()
        {
            this.subscriptionModel = new SubscriptionsModel();
        }

        public async Task<AcctionResult> SaveChanges(AssistsModel assistModel)
        {
            try
            {
                assistModel.Operation = Operation.Delete;

                RepositoryConnection.BeginTransaction();

                AcctionResult action = await assistModel.SaveChanges();

                if (action.Result)
                {
                    subscriptionModel.IdSubscriptions = assistModel.IdSubscriptions;

                    subscriptionModel = await subscriptionModel.GetById();

                    subscriptionModel.UsedSessions -= 1;
                    subscriptionModel.AvailableSessions += 1;
                    subscriptionModel.State = SubscriptionsModel.SubscriptionsStates.Active;
                    subscriptionModel.EndDate = DateTime.MinValue;

                    subscriptionModel.Operation = Operation.Update;

                    action = await subscriptionModel.SaveChanges();

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
