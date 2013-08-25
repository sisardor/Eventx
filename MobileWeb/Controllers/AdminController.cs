using Eventz.Model.Common;
using Eventz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileWeb.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CollectEvents()
        {
            EventsGrabber eventsGrabber = new EventsGrabber();
            eventsGrabber.CollectEvents(DateTime.Now, DateTime.Now.AddDays(1),
                new Location("Canada", "BC", "Vancouver"));
            return null;
        }

    }
}
