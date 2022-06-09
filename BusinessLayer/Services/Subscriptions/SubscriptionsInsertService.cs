using BusinessLayer.Models;
using BusinessLayer.Services.SubscriptionsStrategy;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public class SubscriptionsInsertService : IServiceStrategy<SubscriptionsModel>
    {
        private readonly CurrentAccountsModel currentAccountModel;

        public SubscriptionsInsertService()
        {
            this.currentAccountModel = new CurrentAccountsModel();
        }

        public async Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel)
        {
            subscriptionModel.Operation = Operation.Insert;

            currentAccountModel.Operation = Operation.Insert;
            currentAccountModel.TicketCode = subscriptionModel.TicketCode;
            currentAccountModel.Date = DateTime.Now;
            currentAccountModel.Credit = 0;
            currentAccountModel.Balance = 0;
            currentAccountModel.Debit = subscriptionModel.Price;
            currentAccountModel.Detail = "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "] -> Paquete adquirido: " + subscriptionModel.Package + " {Sesiones: " + subscriptionModel.TotalSessions + " - Inicio: " + subscriptionModel.StartDateString + " - Vencimiento: " + subscriptionModel.ExpireDateString + "}";
            currentAccountModel.IdClients = subscriptionModel.IdClients;

            RepositoryConnection.BeginTransaction();

            try
            {
                AcctionResult action = await currentAccountModel.SaveChanges();

                if (action.Result)
                {
                    subscriptionModel.IdCurrentAccounts = await currentAccountModel.GetLastId();

                    action = await subscriptionModel.SaveChanges();

                    if(action.Result)
                    {
                        RepositoryConnection.Commit();

                        return action;
                    } 
                } 

                RepositoryConnection.RollBack();

                return new AcctionResult(false, action.Message);
            }
            catch(Exception ex)
            {
                RepositoryConnection.RollBack();

                throw ex;
            }
        }
    }
}
