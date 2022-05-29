using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Users
    {
        private int _idUsers;
        private DateTime _registerDate;
        private string _type;
        private string _username;
        private string _password;
        private DateTime _lastConnection;

        public int IdUsers { get => _idUsers; set => _idUsers = value; }
        public DateTime RegisterDate { get => _registerDate; set => _registerDate = value; }
        public string Type { get => _type; set => _type = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime LastConnection { get => _lastConnection; set => _lastConnection = value; }
    }
}
