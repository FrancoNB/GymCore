using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cache
{
    public static class LoginCache
    {
        public static int IdUsers { get; set; }
        public static string Type { get; set; } 
        public static string Username { get; set; }
    }
}
