using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using Microsoft.CSharp;

namespace Meetup.FacebookEz
{
    public class FacebookService
    {
        public void GetEvents()
        {
            var client = new FacebookClient("CAACEdEose0cBAMymCBZA1VTV5bTjWWoyihmMD3hNz3jULulBiHWqsBO5JHLJtqahZBCwkUb0JZC3ZAAbUqZCiyFJsrpn4wC1aHZBOvyCoNiNgrgRLfAQOj3tRZCGoaWwnYZCuFhoUjLIWsc9sobXZBZABgaGcM5ffKlIvzCGJDfzo5ugZDZD");

            var result =  client.GetTaskAsync("fql",
                new
                {
                    q = FacebookRequests.GetTopEvents
                });

            result.Wait();
            dynamic rawEvents = result.Result;
            rawEvents = rawEvents[0];

            List<FacbookEvent> events = new List<FacbookEvent>();

            foreach (dynamic e in rawEvents)
            {
                events.Add(FacbookEvent.Deserealize(e));
            }
        }
    }
}
