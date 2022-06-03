using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Assists
    {
        private int _idAssists;
        private DateTime _date;
        private int _idClients;
        private int _idSubscriptions;

        public int IdAssists { get => _idAssists; set => _idAssists = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdSubscriptions { get => _idSubscriptions; set => _idSubscriptions = value; }
    }
}
