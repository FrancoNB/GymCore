using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Support
{
    public class RepositoryException : Exception
    {
        public int Code { get; private set; }

        public RepositoryException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
