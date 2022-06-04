using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValueObjects
{
    public class Tickets
    {
        public readonly string Value;

        public static Tickets Create(string prefix, int idClient)
        {
            return new Tickets(prefix, idClient);
        }

        public static Tickets Create(string value)
        {
            return new Tickets(value);
        }

        private Tickets(string prefix, int idClient)
        {
            this.Value = prefix.ToUpper() + " - " + idClient.ToString().PadLeft(5 - idClient.ToString().Length, '0') + " - " + DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        private Tickets(string value)
        {
            this.Value = value;
        }
    }
}
