using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class WorkPlans
    {
        private int _idWorkPlans;
        private string _name;
        private string _category;

        public int IdWorkPlans { get => _idWorkPlans; set => _idWorkPlans = value; }
        public string Name { get => _name; set => _name = value; }
        public string Category { get => _category; set => _category = value; }
    }
}
