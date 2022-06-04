using BusinessLayer.Cache;
using BusinessLayer.Mappers;
using BusinessLayer.ValueObjects;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class SubscriptionsModel
    {
        private int _idsubscriptions;
        private Tickets _ticketCode;
        private DateTime _startDate;
        private string _package;
        private double _price;
        private int _totalSessions;
        private int _usedSessions;
        private int _availableSessions;
        private DateTime _endDate;
        private DateTime _expireDate;
        private string _observations;
        private string _state;
        private int _idclients;
        private int _idcurrentAccounts;

        public int IdSubscriptions { get => _idsubscriptions; set => _idsubscriptions = value; }
        public Tickets TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public string StartDateString
        {
            get
            {
                if (StartDate == null)
                {
                    return string.Empty;
                }
                else if (StartDate == DateTime.MinValue)
                {
                    return "Desconocida";
                }
                else
                {
                    return StartDate.ToString("dd/MM/yyyy");
                }

            }
        }
        public string Package { get => _package; set => _package = value; }
        public double Price { get => _price; set => _price = value; }
        public int TotalSessions { get => _totalSessions; set => _totalSessions = value; }
        public int UsedSessions { get => _usedSessions; set => _usedSessions = value; }
        public int AvailableSessions { get => _availableSessions; set => _availableSessions = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string EndDateString
        {
            get
            {
                if (EndDate == null)
                {
                    return string.Empty;
                }
                else if (EndDate == DateTime.MinValue)
                {
                    return "Sin Finalizar";
                }
                else
                {
                    return EndDate.ToString("dd/MM/yyyy");
                }

            }
        }
        public DateTime ExpireDate { get => _expireDate; set => _expireDate = value; }
        public string ExpireDateString
        {
            get
            {
                if (ExpireDate == null)
                {
                    return string.Empty;
                }
                else if (ExpireDate == DateTime.MinValue)
                {
                    return "Desconocida";
                }
                else
                {
                    return ExpireDate.ToString("dd/MM/yyyy");
                }

            }
        }
        public string Observations { get => _observations; set => _observations = value; }
        public string State { get => _state; set => _state = value; }
        public int IdClients { get => _idclients; set => _idclients = value; }
        public int IdCurrentAccounts { get => _idcurrentAccounts; set => _idcurrentAccounts = value; }

        private ISubscriptionsRepository repository;
        public Operation Operation { get; set; }

        public SubscriptionsModel()
        {
            repository = new SubscriptionsRepository();
        }

        public SubscriptionsModel(ISubscriptionsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            try
            {
                string resultMsg;

                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();

                        RepositoryConnection.BeginTransaction();

                        var currentAccountModel = new CurrentAccountsModel()
                        {
                            Operation = Operation.Insert,
                            TicketCode = this.TicketCode,
                            Date = DateTime.Now,
                            Credit = 0,
                            Debit = this.Price,
                            Detail = "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "] -> Paquete adquirido: " + this.Package + " {Sesiones: " + this.TotalSessions + " - Inicio: " + this.StartDateString + " - Vencimiento: " + this.ExpireDateString + "}",
                            IdClients = this.IdClients
                        };

                        var action = await currentAccountModel.SaveChanges();

                        if(!action.Result)
                            return new AcctionResult(false, action.Message);

                        IdCurrentAccounts = await currentAccountModel.GetLastId();

                        await repository.Insert(SubscriptionsMapper.Adapter(this));

                        resultMsg = "Subscripcion guardada correctamente... !";

                        break;

                    case Operation.Invalidate:
                        ValidateInvalidate();
                        await repository.Update(SubscriptionsMapper.Adapter(this));
                        resultMsg = "Subscripcion anulada correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdSubscriptions);
                        resultMsg = "Subscripcion eliminada correctamente... !";
                        break;

                    case Operation.Update:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                SubscriptionsCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                RepositoryConnection.RollBack();

                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<SubscriptionsModel>> GetAll()
        {
            return SubscriptionsMapper.AdapterList(await repository.GetAll());
        }

        public async Task<IEnumerable<SubscriptionsModel>> GetByIdClient()
        {
            return SubscriptionsMapper.AdapterList(await repository.GetByIdClient(IdClients));
        }

        private void ValidateInsert()
        {
            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que asignar la subscripcion... !");

            if (TicketCode != null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante... !");

            if (StartDate == null)
                throw new ArgumentException("Se debe especificar la fecha de inicio de la subscripcion... !");

            if (string.IsNullOrWhiteSpace(Package))
                throw new ArgumentException("Se debe especificar el paquete de subcripcion que se desea aplicar... !");

            if (TotalSessions < 1 || Price < 1 || ExpireDate == null)
                throw new ArgumentException("El paquete de subscribcion ingresado no es valido... !");

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            IdSubscriptions = -1;
            EndDate = DateTime.MinValue;
            State = "Activo";
            UsedSessions = 0;
            AvailableSessions = TotalSessions;
        }

        private void ValidateInvalidate()
        {
            if (IdSubscriptions < 1)
                throw new ArgumentException("No se selecciono ninguna subscripcion para anular... !");
        }

        private void ValidateDelete()
        {
            if (IdSubscriptions < 1)
                throw new ArgumentException("No se selecciono ninguna subscripcion para eliminar... !");
        }
    }
}
