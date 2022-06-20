using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Routines
    {
        private int _idRoutine;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _state;
        private int _idClients;
        private int _idWorkPlans;

        public int IdRoutines { get => _idRoutine; set => _idRoutine = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string State { get => _state; set => _state = value; }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdWorkPlans { get => _idWorkPlans; set => _idWorkPlans = value; }
    }
}
