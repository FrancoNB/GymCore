using BusinessLayer.Cache;
using BusinessLayer.Mappers;
using BusinessLayer.ValueObjects;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class PaymentsModel
    {
        public enum PaymentMethods
        {
            Cash,
            CreditCard,
            DebitCard,
            Check,
            Other,
            Null
        }

        private int _idPayments;
        private Tickets _ticketCode;
        private DateTime _date;
        private PaymentMethods _paymentMethod;
        private double _amount;
        private string _observations;
        private int _idClients;
        private int _idCurrentAccounts;

        public int IdPayments { get => _idPayments; set => _idPayments = value; }
        public Tickets TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string DateString
        {
            get
            {
                if (Date == null)
                {
                    return string.Empty;
                }
                else if (Date == DateTime.MinValue)
                {
                    return "Desconocida";
                }
                else
                {
                    return Date.ToString("dd/MM/yyyy");
                }

            }
        }
        public double Amount { get => _amount; set => _amount = value; }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdCurrentAccounts { get => _idCurrentAccounts; set => _idCurrentAccounts = value; }
        public PaymentMethods PaymentMethod { get => _paymentMethod; set => _paymentMethod = value; }
        public string PaymentMethodString
        {
            get
            {
                if (PaymentMethod == PaymentMethods.Cash)
                    return "Efectivo";
                else if (PaymentMethod == PaymentMethods.CreditCard)
                    return "Tarjeta de Credito";
                else if (PaymentMethod == PaymentMethods.DebitCard)
                    return "Tarjeta de Debito";
                else if (PaymentMethod == PaymentMethods.Check)
                    return "Cheque";
                else if (PaymentMethod == PaymentMethods.Other)
                    return "Otro";
                else
                    return "Indeterminado";
            }

            set
            {
                if (value == "Efectivo")
                    PaymentMethod = PaymentMethods.Cash;
                else if (value == "Tarjeta de Credito")
                    PaymentMethod = PaymentMethods.CreditCard;
                else if (value == "Tarjeta de Debito")
                    PaymentMethod = PaymentMethods.DebitCard;
                else if (value == "Cheque")
                    PaymentMethod = PaymentMethods.Check;
                else if (value == "Otro")
                    PaymentMethod = PaymentMethods.Other;
                else
                    PaymentMethod = PaymentMethods.Null;
            }
        }
        public string Observations { get => _observations; set => _observations = value.Trim(); }

        private IPaymentsRepository repository;
        public Operation Operation { get; set; }

        public PaymentsModel()
        {
            repository = new PaymentsRepository();
        }

        public PaymentsModel(IPaymentsRepository repository)
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
                        await repository.Insert(PaymentsMapper.Adapter(this));
                        resultMsg = "Pago guardado correctamente... !";
                        break;

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(PaymentsMapper.Adapter(this));
                        resultMsg = "Pago modificado correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdPayments);
                        resultMsg = "Pago eliminado correctamente... !";
                        break;

                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                PaymentsCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 1451)
                    return new AcctionResult(false, "El pago que intentas eliminar se encuntra asociado a otros datos, por lo tanto, no es posible eliminarlo... !");

                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<PaymentsModel>> GetAll()
        {
            return PaymentsMapper.AdapterList(await repository.GetAll());
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
        }

        private void ValidateInsert()
        {
            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que cargarle el pago... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de pago... !");

            if (string.IsNullOrWhiteSpace(PaymentMethodString))
                throw new ArgumentException("Se debe especificar el metodo de pago... !");

            if (Amount <= 0)
                throw new ArgumentException("El monto del pago debe ser mayor a $ 0.00... !");

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            if (IdCurrentAccounts < 1)
                throw new ArgumentException("Se debe especificar el registro de cuenta corriente asociado al pago... !");

            IdPayments = -1;
            Date = DateTime.Now;
        }

        private void ValidateUpdate()
        {
            if (IdPayments < 1)
                throw new ArgumentException("No se selecciono ningun pago para modificar... !");

            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que cargarle el pago... !");

            if (TicketCode == null)
                throw new ArgumentException("Se debe especificar un codigo para el comprobante de pago... !");

            if (string.IsNullOrWhiteSpace(PaymentMethodString))
                throw new ArgumentException("Se debe especificar el metodo de pago... !");

            if (Amount <= 0)
                throw new ArgumentException("El monto del pago debe ser mayor a $ 0.00... !");

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            if (IdCurrentAccounts < 1)
                throw new ArgumentException("Se debe especificar el registro de cuenta corriente asociado al pago... !");

            Date = DateTime.Now;
        }

        private void ValidateDelete()
        {
            if (IdPayments < 1)
                throw new ArgumentException("No se selecciono ningun pago para eliminar... !");
        }
    }
}
