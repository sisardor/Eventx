using Newtonsoft.Json.Linq;
/*
 * Created by SharpDevelop.
 * User: Oleg
 * Date: 7/17/2013
 * Time: 2:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Meetup
{
	/// <summary>
	/// Description of Meetup.
	/// </summary>
	public class MeetupEvent
	{
		public string Name;
		public DateTime Time;
		public string Description;
		public MeetupVenue Location;
		public string EventUrl;
		public int YesRSVPCount;

        public static MeetupEvent Deserealize(JObject obj)
        {
            MeetupEvent mEvent = new MeetupEvent();
            mEvent.Name = (string)obj["name"];
            mEvent.Time = DateTime.FromFileTime((long)obj["time"]);
            mEvent.Description = (string)obj["description"];
            mEvent.EventUrl = (string)obj["event_url"];
            mEvent.YesRSVPCount = (int)obj["yes_rsvp_count"];

            return mEvent;
        }

	}
}
