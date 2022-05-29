using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Packages
    {
        private int _idPackages;
        private string _name;
        private int _numberSessions;
        private int _availableDays;
        private double _price;

        public int IdPackages { get => _idPackages; set => _idPackages = value; }
        public string Name { get => _name; set => _name = value; }
        public int NumberSessions { get => _numberSessions; set => _numberSessions = value; }
        public int AvailableDays { get => _availableDays; set => _availableDays = value; }
        public double Price { get => _price; set => _price = value; }

    }
}
