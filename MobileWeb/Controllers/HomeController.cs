using Eventz.Data;
using Eventz.Model.Common;
using Eventz.Services.FacebookEz;
using Eventz.Services.Helper;
using MobileWeb.Helpers;
using MobileWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MobileWeb.Controllers
{
    public class HomeController : Controller
    {
        EventsController eventsCntrl = new EventsController();
        CategoryController categoryCntrl = new CategoryController();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Desktop()
        {
            var events = eventsCntrl.Get(new DateTime(2013, 8, 14), new DateTime(2013, 9, 16));
            ViewBag.Categories = categoryCntrl.GetCategories().ToList();
            return View(events);
        }

        public ActionResult Templates(string template)
        {
            switch (template.ToLower())
            {
                case "event-list":
                    return PartialView("~/Views/Partials/Event-list.cshtml");
                case "create":
                    return PartialView("~/Views/Partials/Create.cshtml");
                case "edit":
                    return PartialView("~/Views/Partials/Edit.cshtml");
                case "event-detail":
                    return PartialView("~/Views/Partials/Event-detail.cshtml");
                default:
                    throw new Exception("template not known");
            }
        }
    }
}
