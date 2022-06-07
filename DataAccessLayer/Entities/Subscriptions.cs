using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Subscriptions
    {
        private int _idsubscriptions;
        private string _ticketCode;
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
        private int _clientsIdclients;
        private int _currentAccountsIdcurrentAccounts;

        public int IdSubscriptions { get => _idsubscriptions; set => _idsubscriptions = value; }
        public string TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public string Package { get => _package; set => _package = value; }
        public double Price { get => _price; set => _price = value; }
        public int TotalSessions { get => _totalSessions; set => _totalSessions = value; }
        public int UsedSessions { get => _usedSessions; set => _usedSessions = value; }
        public int AvailableSessions { get => _availableSessions; set => _availableSessions = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public DateTime ExpireDate { get => _expireDate; set => _expireDate = value; }
        public string Observations { get => _observations; set => _observations = value;}
        public string State { get => _state; set => _state = value; }
        public int IdClients { get => _clientsIdclients; set => _clientsIdclients = value; }
        public int IdCurrentAccounts { get => _currentAccountsIdcurrentAccounts; set=> _currentAccountsIdcurrentAccounts = value; }


    }
    
}
