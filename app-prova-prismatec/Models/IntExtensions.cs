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
            if (value >= 0)
                return new Guid(string.Format("00000000-0000-0000-0000-00{0:0000000000}", value));
            else if (value > Int32.MinValue)
                return new Guid(string.Format("00000000-0000-0000-0000-01{0:0000000000}", Math.Abs(value)));
            else
                return new Guid("00000000-0000-0000-0000-012147483648");
        }
    }
}
