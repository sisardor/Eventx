/*
 * Created by SharpDevelop.
 * User: Oleg
 * Date: 7/17/2013
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Meetup
{
	/// <summary>
	/// Description of MeetupService.
	/// </summary>
	public class MeetupService
	{
		public MeetupService()
		{
		}
		
		public List<MeetupEvent> GetTopEvents(EventzLocation location, DateTime date)
		{
			var meetups = GetEvents(location, date, date);
            meetups = meetups.Where(m => m.YesRSVPCount > 30);
			return meetups.ToList();
		}
		
		public IEnumerable<MeetupEvent> GetEvents(EventzLocation location, DateTime from, DateTime to)
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
            List<MeetupEvent> events = new List<MeetupEvent>();

            foreach (JObject o in jEvents)
            {
                events.Add(MeetupEvent.Deserealize(o));
            }

            return events;
		}
	}
}
