using Meetup.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meetup.FacebookEz
{
    public class FacbookEvent : BaseEvent
    {
        public static FacbookEvent Deserealize(dynamic eventObject)
        {
            FacbookEvent fbEvent = new FacbookEvent();
            fbEvent.Id = eventObject.eid;
            fbEvent.Name = eventObject.name;
            fbEvent.StartTime = DateTime.Parse((string)eventObject.start_time);

            if(!(eventObject.venue is Facebook.JsonArray))
                fbEvent.Venue = FacebookVenue.Deserealize(eventObject.venue);

            fbEvent.AttendingCount = (int)eventObject.attending_count;
            fbEvent.EventUrl = @"https://www.facebook.com/events/" + fbEvent.Id;

            return fbEvent;
        }
    }
}
