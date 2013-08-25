using Eventz.Data;
using Eventz.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Interfaces
{
    public interface IEventsSource
    {
        List<Event> GetTopEvents(DateTime startDate, DateTime endDate, Location location);
    }
}
