using Eventz.Services.FacebookEz;
using MobileWeb.Helpers;
using MobileWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileWeb.Controllers
{
    public class EventsController : BaseApiController
    {
        // GET api/events
        public IEnumerable<events_day> Get(DateTime start_date, DateTime end_date)
        {
            var eventsGrouped = EventsHelper.GetEventsByDay(Context.Events, start_date, end_date);

            return ToViewModel(eventsGrouped);
        }

        // GET api/events
        public IEnumerable<events_day> Get(DateTime start_date, int skip = -1, int top = -1)
        {
            if (skip > 0) start_date.AddDays(skip);
            var end_date = start_date;
            if (top > 0) end_date.AddDays(top);

            var eventsGrouped = EventsHelper.GetEventsByDay(Context.Events, start_date, end_date);

            return ToViewModel(eventsGrouped);
        }

        // GET api/events/5
        public eventt Get(int id)
        {
           var evnt = Context.Events.Find(id);
           if (evnt == null)
               throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
           return new eventt(evnt);
        }

        // POST api/events
        public void Post([FromBody]string value)
        {
        }

        // PUT api/events/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/events/5
        public void Delete(int id)
        {
        }

        private static IEnumerable<events_day> ToViewModel(Dictionary<DateTime, List<Eventz.Data.Event>> eventsGrouped)
        {
            var viewModel = eventsGrouped.Select(e => new events_day()
            {
                date = e.Key,
                events = e.Value.Select(ev => new eventt(ev)).ToList()
            }).ToList();

            return viewModel;
        }

    }
}
