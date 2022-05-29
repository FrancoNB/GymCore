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
        private int _ticketCode;
        private DateTime _start_date;
        private string _package;
        private double _price;
        private int _total_sessions;
        private int _used_sessions;
        private int _available_sessions;
        private DateTime _end_date;
        private DateTime _expire_date;
        private string _observations;
        private string _state;
        private int _clients_idclients;
        private int _current_accounts_idcurrent_accounts;

        public int IdSubscriptions { get => _idsubscriptions; set => _idsubscriptions = value; }
        public int TicketCode { get => _ticketCode; set => _ticketCode = value; }
        public DateTime StartDate { get => _start_date; set => _start_date = value; }
        public string Package { get => _package; set => _package = value; }
        public double Price { get => _price; set => _price = value; }
        public int TotalSessions { get => _total_sessions; set => _total_sessions = value; }
        public int UsedSessions { get => _used_sessions; set => _used_sessions = value; }
        public int AvailableSessions { get => _available_sessions; set => _available_sessions = value; }
        public DateTime EndDate { get => _end_date; set => _end_date = value; }
        public DateTime ExpireDate { get => _expire_date; set => _expire_date = value; }
        public string Observations { get => _observations; set => _observations = value;}
        public string State { get => _state; set => _state = value; }
        public int ClientsIdClients { get => _clients_idclients; set => _clients_idclients = value; }
        public int CurrentAccountsIdCurrentAccounts { get => _current_accounts_idcurrent_accounts; set=> _current_accounts_idcurrent_accounts = value; }


    }
    
}
