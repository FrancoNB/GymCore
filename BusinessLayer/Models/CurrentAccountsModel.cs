using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class CurrentAccountsModel
    {
        private int _idCurrentAccounts;
        private string _ticketCode;
        private DateTime _date;
        private double _credit;
        private double _debit;
        private double _balance;
        private string _detail;
        private int _idClients;

        public int IdCurrentAccounts { get { return _idCurrentAccounts; } set { _idCurrentAccounts = value; } }
        public string TicketCode { get { return _ticketCode; } set { _ticketCode = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public double Credit { get { return _credit; } set { _credit = value; } }
        public double Debit { get { return _debit; } set { _debit = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
        public string Detail { get { return _detail; } set { _detail = value; } }
        public int IdClients { get { return _idClients; } set { _idClients = value; } }

        private ICurrentAccountsRepository repository;

        public Operation Operation { get; set; }

        public CurrentAccountsModel()
        {
            repository = new CurrentAccountsRepository();
        }

        public CurrentAccountsModel(ICurrentAccountsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            try
            {
                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        return new AcctionResult(true, "Cuenta Corriente guardada correctamente... !");
                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        return new AcctionResult(true, "Cuenta Corriente actualizada correctamente... !");
                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdCurrentAccounts);
                        return new AcctionResult(true, "Cuenta Corriente eliminada correctamente... !");
                    default:
                        return new AcctionResult(false, "No se establecio la operación a realizar... !");
                }
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<CurrentAccountsModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<CurrentAccountsModel>();

            foreach (CurrentAccounts item in dataModel)
            {
                list.Add(new CurrentAccountsModel
                {
                    IdCurrentAccounts = item.IdCurrentAccounts,
                    Date = item.Date,
                    TicketCode = item.TicketCode,
                    Debit = item.Debit,
                    Credit = item.Credit,
                    Balance = item.Balance,
                    Detail = item.Detail,
                    IdClients = item.IdClients,
                });
            }

            return list;
        }

        private CurrentAccounts GetDataEntity()
        {
            return new CurrentAccounts()
            {
                IdCurrentAccounts = this.IdCurrentAccounts,
                Date = this.Date,
                TicketCode = this.TicketCode,
                Debit = this.Debit,
                Credit = this.Credit,
                Balance = this.Balance,
                Detail = this.Detail,
                IdClients = this.IdClients,
            };
        }

        private void ValidateInsert()
        {

        }

        private void ValidateUpdate()
        {

        }

        private void ValidateDelete()
        {

        }
    }
}
