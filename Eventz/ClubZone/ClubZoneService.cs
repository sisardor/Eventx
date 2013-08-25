using CsQuery;
using CsQuery.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Meetup.ClubZone
{
    public class ClubZoneService
    {
        public void GetEvents()
        {
            using (WebClient client = new WebClient())
            {
                string baseUrl = "http://www.clubzone.com";
                
                CQ html = client.DownloadString("http://www.clubzone.com/events/1/vancouver/july/19/2013");
                CQ pages = html["div.paging > a"];

                foreach (DomElement page in pages)
                {
                    string pageUrl = page.Attributes["href"];
                    if(!String.IsNullOrEmpty(pageUrl.Trim()) && pageUrl != "#")
                    {
                        //ProcessListingPage(baseUrl, pageUrl);
                    }
                }
            }
        }

        private void ProcessListingPage(string baseUrl, string pageUrl)
        {
            using (WebClient client = new WebClient())
            {
                CQ html = client.DownloadString("pageUrl");

                CQ events = html["div.ListPanel > div.MediumListItem"];

                foreach (DomElement e in events)
                {
                    CQ eventCQ = CQ.Create(e);
                    string title = eventCQ["a.description"].Text();
                    string eventLink = PathCombine(baseUrl, eventCQ["a.description"].Attr("href"));
                    string venue = eventCQ["#vcard > a"].Text();
                    string street = eventCQ["#vcard > span.adr > span.street-address"].Text();
                    string city = eventCQ["#vcard > span.adr > span.locality"].Text();
                    string state = eventCQ["#vcard > span.adr > span.region"].Text();

                    ProcessEventPage(baseUrl, eventLink);
                }
            }
        }

        private void ProcessEventPage(string baseUrl, string eventLink)
        {
            using (WebClient client = new WebClient())
            {
                CQ html = client.DownloadString(eventLink);

                string largeImageUrl = html["div.poster img.photo"].Attr("src");
                byte[] imageData = client.DownloadData(largeImageUrl);
                string htmlDescription = html["div.clientHTML"].Html();
            }
        }

        public static string PathCombine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}", uri1, uri2);
        }
    }
}
