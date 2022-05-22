using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValueObjects
{
    public class AcctionResult
    {
        public bool Result { get; private set; }
        public string Message { get; private set; }

        public AcctionResult(bool result, string message = "-")
        {
            Result = result;
            Message = message;
        }
    }
}
