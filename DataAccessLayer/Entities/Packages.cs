using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Packages
    {
        private int _idpackages;
        private string _name;
        private int _number_sessions;
        private int _available_days;
        private double _price;

        public int IdPackages { get => _idpackages; set => _idpackages = value; }
        public string Name { get => _name; set => _name = value; }
        public int NumberSessions { get => _number_sessions; set => _number_sessions = value; }
        public int AvailableDays { get => _available_days; set => _available_days = value; }
        public double Price { get => _price; set => _price = value; }

    }
}
