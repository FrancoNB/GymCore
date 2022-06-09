using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Support;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Payments
{
    public class PaymentsInsertService : IServiceStrategy<PaymentsModel>
    {
        private readonly CurrentAccountsModel currentAccountModel;

        public PaymentsInsertService()
        {
            this.currentAccountModel = new CurrentAccountsModel();
        }

        public async Task<AcctionResult> SaveChanges(PaymentsModel paymentModel)
        {
            paymentModel.Operation = Operation.Insert;

            currentAccountModel.Operation = Operation.Insert;
            currentAccountModel.TicketCode = paymentModel.TicketCode;
            currentAccountModel.Date = DateTime.Now;
            currentAccountModel.Credit = paymentModel.Amount;
            currentAccountModel.Balance = 0;
            currentAccountModel.Debit = 0;
            currentAccountModel.Detail = "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "] -> Pago realizado - Medio de pago: " + paymentModel.PaymentMethodString;
            currentAccountModel.IdClients = paymentModel.IdClients;

            RepositoryConnection.BeginTransaction();

            try
            {
                AcctionResult action = await currentAccountModel.SaveChanges();

                if (action.Result)
                {
                    paymentModel.IdCurrentAccounts = await currentAccountModel.GetLastId();

                    action = await paymentModel.SaveChanges();

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
