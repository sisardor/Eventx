using Eventz.Data;
using Eventz.Model.Common;
using Eventz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Meetup
{
    public class MeetupStorage : IEventsStorage
    {
        public void SaveToDb(List<Event> events, UpdateInterval interval)
        {

        }
        public IQueryable<Event> LoadFromDb()
        {
            return new List<Event>().AsQueryable();
        }

        public DateTime LastUpdated
        {
            get { return DateTime.Now.AddHours(-2); }
        }

        DateTime IEventsStorage.LastUpdated(UpdateInterval interval)
        {
            return DateTime.Now;
        }
    }
}
