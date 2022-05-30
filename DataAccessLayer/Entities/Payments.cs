using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Payments
    {
        private int _idPayments;
        private string _ticketCode;
        private DateTime _date;
        private string _paymentMethod;
        private double _amount;
        private string _observations;
        private int _idClients;
        private int _idCurrentAccounts;

        public int IdPayments { get => _idPayments; set => _idPayments = value; }
        public string TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdCurrentAccounts { get => _idCurrentAccounts; set => _idCurrentAccounts = value; }
        public string PaymentMethod { get => _paymentMethod; set => _paymentMethod = value; }
        public string Observations { get => _observations; set => _observations = value; }
    }
}
