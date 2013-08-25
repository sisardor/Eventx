using Eventz.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Parsers
{
    public class MeetupEventParser
    {
        public static Event Parse(JObject obj)
        {
            Event mEvent = new Event();
            mEvent.Name = (string)obj["name"];
            mEvent.StartTime = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)obj["time"]);
            mEvent.Description = (string)obj["description"];
            mEvent.EventUrl = (string)obj["event_url"];
            mEvent.AttendingCount = (int)obj["yes_rsvp_count"];

            return mEvent;
        }
    }
}
