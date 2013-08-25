using Eventz.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Eventz.Services.Helper;
using Eventz.Model.Common;
using Eventz.Services.Interfaces;

namespace Eventz.Services
{
    public class EventLoader
    {
        //. Move to DB
        private static int WeeklyUpdateIntervalHours = 24;
        private static int WeeklyUpdateDays = 7;

        private static int ClosesEventsUpdateIntervalHours = 4;
        private static int ClosesEventsUpdateDays = 3;

        private static int TodayUpdateIntervalHours = 1;
        private static int TodayUpdateDays = 3;

        private Timer timer;

        public EventLoader()
        {
            timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
        }

        public void Start()
        {
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (IEventProvider provider in EventsFactory.Instance.GetAllEventsProviders())
            {
                LoadEvents(provider, WeeklyUpdateIntervalHours, WeeklyUpdateDays, UpdateInterval.Week);
                LoadEvents(provider, ClosesEventsUpdateIntervalHours, ClosesEventsUpdateDays, UpdateInterval.Closest);
                LoadEvents(provider, TodayUpdateIntervalHours, TodayUpdateDays, UpdateInterval.Today);
            }
        }

        private void LoadEvents(IEventProvider provider, int updateIntervalHours, int updateDays, UpdateInterval interval)
        {
            if (!provider.Storage.LastUpdated(interval).WithInHours(updateIntervalHours))
            {
                var events = provider.Source.GetTopEvents(DateTime.Now, DateTime.Now.AddDays(updateDays), Locations.Vancouver);
                provider.Storage.SaveToDb(events, interval);
            }
        }


    }
}
