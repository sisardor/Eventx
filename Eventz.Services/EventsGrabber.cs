using Eventz.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventz.Services.Common;
using Eventz.Model;

namespace Eventz.Services
{
    public class EventsGrabber
    {
        public void CollectEvents(DateTime startDate, DateTime endDate, Location location)
        {
            foreach (IEventProvider provider in EventsFactory.Instance.GetAllEventsProviders())
            {
                var events = provider.Source.GetTopEvents(startDate, endDate, location);
                provider.Storage.SaveToDb(events, Interfaces.UpdateInterval.Today);
            }
        }
    }
}
