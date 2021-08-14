using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec.Models
{
    public static class IntExtensions
    {
        public static Guid ToGuid(this Int32 value)
        {
            if (value >= 0) // if value is positive
                return new Guid(string.Format("00000000-0000-0000-0000-00{0:0000000000}", value));
            else if (value > Int32.MinValue) // if value is negative
                return new Guid(string.Format("00000000-0000-0000-0000-01{0:0000000000}", Math.Abs(value)));
            else //if (value == Int32.MinValue)
                return new Guid("00000000-0000-0000-0000-012147483648");  // Because Abs(-12147483648) generates a stack overflow due to being > 12147483647 (Int32.Max)
        }
    }
}
