using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Helper
{
    public static class Extensions
    {
        public static bool WithInHours(this DateTime date, int hours)
        {
            return DateTime.UtcNow < date.AddHours(hours);
        }    
    }
}
