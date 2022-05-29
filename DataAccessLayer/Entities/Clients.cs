using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Clients
    {
        private int _idClients;
        private DateTime _date;
        private string _name;
        private string _surname;
        private string _locality;
        private string _address;
        private string _phone;
        private string _mail;
        private string _observations;

        public int IdClients { get { return _idClients; } set { _idClients = value; } }
        public DateTime RegisterDate { get { return _date; } set { _date = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Locality { get { return _locality; } set { _locality = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string Observations { get { return _observations; } set { _observations = value; } }
    }
}
