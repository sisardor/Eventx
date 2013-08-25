using Eventz.Model.Common;
using Eventz.Data;
using Eventz.Services.Interfaces;
using Eventz.Services.Parsers;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Meetup
{
    public class MeetupSource : IEventsSource
    {
        public List<Event> GetTopEvents(DateTime startDate, DateTime endDate, Location location)
        {
            var meetups = GetEvents(startDate, endDate, location);
            //meetups = meetups.Where(m => m.AttendingCount > 30);
            return meetups.ToList();
        }

        public IEnumerable<Event> GetEvents(DateTime startDate, DateTime endDate, Location location)
        {
            var client = new RestClient("https://api.meetup.com");

            var request = new RestRequest("/2/open_events", Method.GET);
            request.AddParameter("key", "3064102e7b146c2e505e35258f5a");
            request.AddParameter("status", "upcoming");
            //request.AddParameter("lon", "-123.1119");
            //request.AddParameter("lat", "49.2505");
            request.AddParameter("lon", "-122.4183");
            request.AddParameter("lat", "37.7750");
            //request.AddParameter("category", "23");
            //request.AddParameter("page", "2000");
            request.AddParameter("radius", "30");


            IRestResponse response = client.Execute(request);
            string json = response.Content;

            JObject obj = JObject.Parse(json);

            JArray results = (JArray)obj["results"];
            var jEvents = results.Select(r => r.Value<JObject>());
            List<Event> events = new List<Event>();

            foreach (JObject o in jEvents)
            {
                events.Add(MeetupEventParser.Parse(o));
            }

            return events;
        }
    }
}
