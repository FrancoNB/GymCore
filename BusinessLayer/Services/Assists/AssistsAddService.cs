using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Assists
{
    public class AssistsAddService : IServiceStrategy<AssistsModel>
    {
        private SubscriptionsModel subscriptionModel;

        public AssistsAddService()
        {
            this.subscriptionModel = new SubscriptionsModel();
        }

        public async Task<AcctionResult> SaveChanges(AssistsModel assistModel)
        {
            try
            {  
                if((await assistModel.GetAll()).ToList().FindAll(assist => assist.Date.Date == assistModel.Date.Date && assist.IdClients == assistModel.IdClients).Count > 0)
                    return new AcctionResult(false, "La asistencia del cliente en la fecha seleccionada ya se encuentra cargada... !");

                subscriptionModel.IdClients = assistModel.IdClients;

                subscriptionModel = (await subscriptionModel.GetAll()).ToList().Find(subscription => subscription.State == SubscriptionsModel.SubscriptionsStates.Active && subscription.IdClients == assistModel.IdClients);

                if(subscriptionModel == null)
                    return new AcctionResult(false, "El cliente no cuenta con subscripciones activas, no se puede cargar una asistencia... !");

                RepositoryConnection.BeginTransaction();

                assistModel.IdSubscriptions = subscriptionModel.IdSubscriptions;

                assistModel.Operation = Operation.Insert;

                AcctionResult action = await assistModel.SaveChanges();

                if (action.Result)
                {
                    subscriptionModel.UsedSessions += 1;
                    subscriptionModel.AvailableSessions -= 1;

                    if (subscriptionModel.UsedSessions == subscriptionModel.TotalSessions)
                    {
                        subscriptionModel.State = SubscriptionsModel.SubscriptionsStates.Finished;
                        subscriptionModel.EndDate = DateTime.Now;
                    }                       

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
