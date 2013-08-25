using Eventz.Data;
using Eventz.Model.Common;
using Eventz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eventz.Services.FacebookEz
{
    public class FacebookStorage : IEventsStorage
    {
        //. Hack. Ask Sergey how to do better
        private EntitiesContext dbContext;

        public FacebookStorage()
        {
            dbContext = new EntitiesContext();
        }

        public void SaveToDb(List<Event> events, UpdateInterval interval)
        {
            using (var dbContext = new EntitiesContext())
            {
                foreach(var evnt in events)
                {
                    //. Optimize. Use stored proc. Use hash or index for url comparation

                    if (dbContext.Events.Any(e => e.EventUrl == evnt.EventUrl))
                    {
                        // update
                    }
                    else
                    {
                        dbContext.Events.Add(evnt);
                    }
                }

                //RefreshLastUpdatedStorageTime(interval, dbContext);
                dbContext.SaveChanges();
            }
        }

        private static void RefreshLastUpdatedStorageTime(UpdateInterval interval, EntitiesContext dbContext)
        {
            var storage = dbContext.Storages.Where(s => s.StorageType == StorageType.Facebook).Single();

            if (interval == UpdateInterval.Today)
                storage.LastUpdatedToday = DateTime.Now;
            if (interval == UpdateInterval.Closest)
                storage.LastUpdatedClosest = DateTime.Now;
            if (interval == UpdateInterval.Week)
                storage.LastUpdatedClosest = DateTime.Now;
        }

        public IQueryable<Event> LoadFromDb()
        {
            return dbContext.Events;
        }

        public DateTime LastUpdated(UpdateInterval interval)
        {
            using (var dbContext = new EntitiesContext())
            {
                var storage = dbContext.Storages.Where(s => s.StorageType == StorageType.Facebook).Single();

                if (interval == UpdateInterval.Today) return storage.LastUpdatedToday;
                if (interval == UpdateInterval.Closest) return storage.LastUpdatedClosest;
                if (interval == UpdateInterval.Week) return storage.LastUpdatedWeek;

                return DateTime.MinValue;
            }
        }
    }
}
