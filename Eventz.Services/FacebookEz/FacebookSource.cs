using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using Microsoft.CSharp;
using Eventz.Data;
using Eventz.Services.Parsers;
using Eventz.Model.Common;
using Eventz.Services.Interfaces;

namespace Eventz.Services.FacebookEz
{
    public class FacebookSource : IEventsSource
    {
        public List<Event> GetTopEvents(DateTime startDate, DateTime endDate, Location location)
        {
            var client = new FacebookClient(FacebookRequests.AccessToken);

            string queryString = String.Format(FacebookRequests.GetTopEvents,
                        location.City,
                        startDate.ToString(FacebookRequests.DateTimeFormat),
                        endDate.ToString(FacebookRequests.DateTimeFormat)
                        );

            var result =  client.GetTaskAsync("fql",
                new
                {
                    q = queryString
                });

            result.Wait();
            dynamic rawEvents = result.Result;
            rawEvents = rawEvents[0];

            List<Event> events = new List<Event>();

            foreach (dynamic e in rawEvents)
            {
                events.Add(FacebookEventParser.Parse(e));
            }

            return events;
        }
    }
}
