using Eventz.Data;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace MobileWeb.Helpers
{
    public class EventsHelper
    {
        public static Dictionary<DateTime, List<Event>> GetEventsByDay(IQueryable<Event> events, 
            DateTime startDate, 
            DateTime endDate)
        {
            var result = (from ev in events
                          where ev.StartTime >= startDate && ev.StartTime <= endDate
                     group ev by EntityFunctions.TruncateTime(ev.StartTime) into g
                     select new { Date = g.Key.Value, Events = g.OrderBy(ev => ev.StartTime).Select(e => e) });

            

            return result.ToDictionary(e => e.Date, e => e.Events.ToList());
        }
    }
}