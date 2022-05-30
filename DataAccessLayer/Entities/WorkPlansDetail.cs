using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class WorkPlansDetail
    {
        private int _idWorkPlansDetail;
        private int _day;
        private int _idWorkPlans;
        private int _idWorks;

        public int IdWorkPlansDetail { get => _idWorkPlansDetail; set => _idWorkPlansDetail = value; }
        public int Day { get => _day; set => _day = value; }
        public int IdWorkPlans { get => _idWorkPlans; set => _idWorkPlans = value; }
        public int IdWorks { get => _idWorks; set => _idWorks = value; }
    }
}
