using BusinessLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Support
{
    public interface IServiceStrategy<Model> where Model : class
    {
        Task<AcctionResult> SaveChanges(Model model);
    }
}
