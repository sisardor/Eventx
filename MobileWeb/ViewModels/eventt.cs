using Eventz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWeb.Models
{
    public class events_day
    {
        public DateTime date;
        public List<eventt> events = new List<eventt>();
    }

    public class eventt
    {
        public eventt()
        {
        }

        public eventt(Event eventEntity)
        {
            name = eventEntity.Name;
            date = eventEntity.StartTime.ToShortDateString();
            time = eventEntity.StartTime.ToShortTimeString();
            Categories = eventEntity.Categories.ToList();
            venue = eventEntity.Venue == null ? "" : !String.IsNullOrEmpty(eventEntity.Venue.Name) 
                ? eventEntity.Venue.Name : eventEntity.Venue.Street;
            var img = eventEntity.Images.Where(i => i.Type == 1).SingleOrDefault();
            image_url = img.Url ?? "";
            event_url = eventEntity.EventUrl;
            attending_count = eventEntity.AttendingCount;
        }

        public eventt(string name, string time, string venue, int? attending_count, string image_url)
        {
            name = this.name;
            time = this.time;
            venue = this.venue;
            attending_count = this.attending_count;
            image_url = this.image_url;
        }

        public string name;
        public string date;
        public string time;
        public string venue;
        public string image_url;
        public string event_url;
        public int? attending_count;
        public List<Category> Categories;
    }
}