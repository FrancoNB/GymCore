using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.ValueObjects;

namespace BusinessLayer.Support
{
    public interface IStrategy
    {
        Task<AcctionResult> SaveChanges();
    }
}
