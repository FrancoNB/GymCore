using BusinessLayer.Mappers;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
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
        private Tickets _ticketCode;
        private DateTime _date;
        private double _credit;
        private double _debit;
        private double _balance;
        private string _detail;
        private int _idClients;

        public int IdCurrentAccounts { get { return _idCurrentAccounts; } set { _idCurrentAccounts = value; } }
        public Tickets TicketCode { get { return _ticketCode; } set { _ticketCode = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public double Credit { get { return _credit; } set { _credit = value; } }
        public double Debit { get { return _debit; } set { _debit = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
        public string Detail { get { return _detail; } set { _detail = value.Trim(); } }
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
                        await repository.Insert(CurrentAccountsMapper.Adapter(this));    
                        return new AcctionResult(true, "Cuenta Corriente guardada correctamente... !");

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(CurrentAccountsMapper.Adapter(this));
                        return new AcctionResult(true, "Cuenta Corriente actualizada correctamente... !");

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdCurrentAccounts);
                        return new AcctionResult(true, "Cuenta Corriente eliminada correctamente... !");

                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operación a realizar... !");
                }
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
        }

        public async Task<IEnumerable<CurrentAccountsModel>> GetAll()
        {
            return CurrentAccountsMapper.AdapterList(await repository.GetAll());
        }

        private void ValidateInsert()
        {
            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningún cliente para asignarle un registro de cuenta corriente... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de la cuenta corriente... !");

            if (string.IsNullOrEmpty(Detail))
                Detail = "-";

            IdCurrentAccounts = -1;
            Date = DateTime.Now;
        }

        private void ValidateUpdate()
        {
            if (IdCurrentAccounts < 1)
                throw new ArgumentException("No se selecciono ninguna cuenta corriente... !");

            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningún cliente para asignarle un registro de cuenta corriente... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de la cuenta corriente... !");

            if (string.IsNullOrEmpty(Detail))
                Detail = "-";
        }

        private void ValidateDelete()
        {
            if (IdCurrentAccounts < 1)
                throw new ArgumentException("No se selecciono ninguna cuenta corriente para eliminar... !");
        }
    }
}
