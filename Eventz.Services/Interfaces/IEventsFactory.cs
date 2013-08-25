using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Interfaces
{
    public class EventSourceType
    {
        public EventSourceType(string type)
        {
            Type = type;
        }

        public string Type;
    }
}
