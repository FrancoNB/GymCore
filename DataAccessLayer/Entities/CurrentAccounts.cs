using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CurrentAccounts
    {
        private int _idCurrentAccounts;
        private string _ticketCode;
        private DateTime _date;
        private double _credit;
        private double _debit;
        private double _balance;
        private string _detail;
        private int _idClients;

        public int IdCurrentAccounts { get => _idCurrentAccounts; set => _idCurrentAccounts = value; }
        public string TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public double Debit { get => _debit; set => _debit = value; }   
        public int IdClients { get => _idClients; set => _idClients = value; }
        public double Credit { get => _credit; set => _credit = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public string Detail { get => _detail; set => _detail = value; }
    }
}
