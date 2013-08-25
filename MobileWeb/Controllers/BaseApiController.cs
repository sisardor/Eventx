using Eventz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MobileWeb.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            Context = new EntitiesContext();
        }

        public EntitiesContext Context { get; private set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }
    }
}
