using System;
using System.Linq;
using Eventz.Data;
using Eventz.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventz.Services.FacebookEz;
using Eventz.Model.Common;
using System.Collections.Generic;
using Eventz.Data;
using Eventz.Services;
using Eventz.Model;
using Eventz.Services.Common;
using Eventz.Services.Interfaces;

namespace Events.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestFacebookStorageSaveandLoad()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event() { AttendingCount = 10, Description = "FB Event", EventUrl = "http://google.com",
                Name = "FB Event Name", StartTime = new DateTime(2013, 10, 11)});
            events.Add(new Event()
            {
                AttendingCount = 10,
                Description = "FB Event 2",
                EventUrl = "http://google.com",
                Name = "FB Event Name 2", StartTime = new DateTime(2013, 10, 11)});


            FacebookStorage storage = new FacebookStorage();
           // storage.SaveToDb(events);

            var eventsLoaded = storage.LoadFromDb();

            //Assert.AreEqual(events.Count, eventsLoaded.Count);
        }

        [TestMethod]
        public void TestEventsGrabber()
        {
            EventsGrabber grabber = new EventsGrabber();
            grabber.CollectEvents(DateTime.Now, DateTime.Now.AddDays(5), Locations.Vancouver);
            Assert.IsTrue(DB.Events.Count > 0);
        }

        [TestMethod]
        public void GrabMeetupData()
        {
            var provider = EventsFactory.Instance.EventsProviders["meetup"];
            var events = provider.Source.GetTopEvents(DateTime.Now, DateTime.Now.AddDays(15), Locations.Vancouver);

            using (var dbContext = new EntitiesContext())
            {
                events.ForEach(e => dbContext.Events.Add(e));
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDB()
        {
            FacebookStorage fb = new FacebookStorage();
            Event evnt = new Event()
            {
                AttendingCount = 0,
                Description = "Descr",
                Name = "test",
                StartTime = DateTime.Now,
                State = 0,
                EventUrl = "sdf"
            };
            var events = new List<Event>();
            events.Add(evnt);

           // fb.SaveToDb(events);

            var events2 = fb.LoadFromDb();
        }
    }
}
