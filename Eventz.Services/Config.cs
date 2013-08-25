using Eventz.Services.Common;
using Eventz.Services.FacebookEz;
using Eventz.Services.Meetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services
{
    public static class Config
    {
        public static int ReloadInterval = 5;
    }

    public class Initialization
    {
        public static void RegisterEventProviders()
        {
            EventsFactory.Instance.RegisterEventProvider("facebook", new FacebookSource(), new FacebookStorage());
            EventsFactory.Instance.RegisterEventProvider("meetup", new MeetupSource(), new MeetupStorage());
        }
    }
}
