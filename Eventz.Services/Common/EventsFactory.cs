using Eventz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Common
{
    public class EventsFactory
    {
        public static EventsFactory _instance;

        public static EventsFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventsFactory();
                    Initialization.RegisterEventProviders();
                }

                return _instance;
            }
        }
        
        public Dictionary<string, IEventProvider> EventsProviders = new Dictionary<string, IEventProvider>();

        public void RegisterEventProvider(string type, IEventsSource source, IEventsStorage storage)
        {
            EventsProviders.Add(type, new EventProvider(type, source, storage)); 
        }

        public List<IEventProvider> GetAllEventsProviders()
        {
            return EventsProviders.Values.ToList();
        }
    }
}
