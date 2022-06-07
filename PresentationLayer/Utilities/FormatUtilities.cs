using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Utilities
{
    public static class FormatUtilities
    {
        public static double NumbersOnly(string value)
        {
            const string validCharacters = "0123456789.";

            string result = string.Empty;
            
            value = value.Trim();

            for(int i = 0; i < value.Length; i++)
            {
                if(validCharacters.Contains(value.Substring(i, 1)))
                {
                    result += value.Substring(i, 1);
                }
            }

            return string.IsNullOrWhiteSpace(result) ? 0 : Convert.ToDouble(result);
        }

        public static bool IsDate(string value)
        {
            return DateTime.TryParse(value, out _);
        }
    }
}
