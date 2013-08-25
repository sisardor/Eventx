using Eventz.Data;
using Eventz.Services.FacebookEz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Parsers
{
    public class FacebookEventParser
    {
        public static Event Parse(dynamic eventObject)
        {
            Event fbEvent = new Event();
            fbEvent.Id = eventObject.eid;
            fbEvent.Name = eventObject.name;
            fbEvent.Description = eventObject.description;
            fbEvent.StartTime = DateTime.Parse((string)eventObject.start_time);

            if (!(eventObject.venue is Facebook.JsonArray))
                fbEvent.Venue = FacebookHelper.DeserealizeVenue(eventObject.venue);

            fbEvent.AttendingCount = (int)eventObject.attending_count;
            fbEvent.EventUrl = @"https://www.facebook.com/events/" + fbEvent.Id;

            Image img = new Image()
            {
                Type = 1, //. Enum. Small Image
                Url = @"http://graph.facebook.com/" + fbEvent.Id + @"/picture"
            };

            //Download file

            return fbEvent;
        }
    }
}
