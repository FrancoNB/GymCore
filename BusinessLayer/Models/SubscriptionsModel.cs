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
        public enum SubscriptionsStates
        {
            Active,
            Canceled,
            Finished,
            Expired,
            Null
        }

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
        private SubscriptionsStates _state;
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
        public SubscriptionsStates State { get => _state; set => _state = value; }
        public string StateString
        {
            get
            {
                if (State == SubscriptionsStates.Active)
                    return "Activa";
                else if (State == SubscriptionsStates.Canceled)
                    return "Anulada";
                else if (State == SubscriptionsStates.Finished)
                    return "Finalizada";
                else if (State == SubscriptionsStates.Expired)
                    return "Vencida";
                else
                    return "Indeterminado";
            }

            set
            {
                if (value == "Activa")
                    State = SubscriptionsStates.Active;
                else if (value == "Anulada")
                    State = SubscriptionsStates.Canceled;
                else if (value == "Finalizada")
                    State = SubscriptionsStates.Finished;
                else if (value == "Vencida")
                    State = SubscriptionsStates.Expired;
                else
                    State = SubscriptionsStates.Null;
            }
        }
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
                        await repository.Insert(SubscriptionsMapper.Adapter(this));
                        resultMsg = "Subscripcion guardada correctamente... !";
                        break;

                    case Operation.Invalidate:
                        ValidateInvalidate();
                        await repository.UpdateState(IdSubscriptions, StateString);
                        resultMsg = "Subscripcion anulada correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdSubscriptions);
                        resultMsg = "Subscripcion eliminada correctamente... !";
                        break;

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(SubscriptionsMapper.Adapter(this));
                        resultMsg = "Subscripcion modificada correctamente... !";
                        break;

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                SubscriptionsCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 1451)
                    return new AcctionResult(false, "La subscripcion que intentas eliminar se encuntra asociada a otros datos, por lo tanto, no es posible eliminarla... !");

               return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<SubscriptionsModel>> GetAll()
        {
            return SubscriptionsMapper.AdapterList(await repository.GetAll());
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
        }

        public async Task<SubscriptionsModel> GetById()
        {
            return SubscriptionsMapper.Adapter(await repository.GetById(IdSubscriptions));
        }

        private void ValidateInsert()
        {
            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que asignar la subscripcion... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de subscripcion... !");

            if (StartDate == null)
                throw new ArgumentException("Se debe especificar la fecha de inicio de la subscripcion... !");

            if (string.IsNullOrWhiteSpace(Package))
                throw new ArgumentException("Se debe especificar el paquete de subcripcion que se desea aplicar... !");

            if (TotalSessions < 1 || Price < 1 || ExpireDate == null)
                throw new ArgumentException("El paquete de subscribcion ingresado no es valido... !");

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            if (IdCurrentAccounts < 1)
                throw new ArgumentException("Se debe especificar el registro de cuenta corriente asociado a la suscripcion... !");

            IdSubscriptions = -1;
            EndDate = DateTime.MinValue;
            State = SubscriptionsStates.Active;
            UsedSessions = 0;
            AvailableSessions = TotalSessions;
        }

        private void ValidateUpdate()
        {
            if (IdSubscriptions < 1)
                throw new ArgumentException("No se establecio la subscripcion que se desea modificar... !");

            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que pertenece la subscripcion... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de subscripcion... !");

            if (StartDate == null)
                throw new ArgumentException("Se debe especificar la fecha de inicio de la subscripcion... !");

            if (string.IsNullOrWhiteSpace(Package))
                throw new ArgumentException("Se debe especificar el paquete de subcripcion que se desea aplicar... !");

            if (TotalSessions < 1 || Price < 1 || ExpireDate == null)
                throw new ArgumentException("El paquete de subscribcion ingresado no es valido... !");

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            if (IdCurrentAccounts < 1)
                throw new ArgumentException("Se debe especificar el registro de cuenta corriente asociado a la suscripcion... !");

            if (EndDate == null)
                EndDate = DateTime.MinValue;

            if (UsedSessions < 0)
                throw new ArgumentException("El numero de clases consumidas no puede ser un numero negativo... !");

            if (AvailableSessions < 0)
                throw new ArgumentException("El numero de clases restantes no puede ser un numero negativo... !");

            if (AvailableSessions + UsedSessions != TotalSessions)
                throw new ArgumentException("El numero de clases restantes sumado al numero de clases consumidas debe ser igual al total de clases que ofrece el paquete... !");

            if (State == SubscriptionsStates.Null)
                throw new ArgumentException("Se debe especificar el estado de la subscripcion... !");
        }

        private void ValidateInvalidate()
        {
            if (IdSubscriptions < 1)
                throw new ArgumentException("No se selecciono ninguna subscripcion para anular... !");

            State = SubscriptionsStates.Canceled;
        }

        private void ValidateDelete()
        {
            if (IdSubscriptions < 1)
                throw new ArgumentException("No se selecciono ninguna subscripcion para eliminar... !");
        }
    }
}
