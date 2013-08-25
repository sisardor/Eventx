using Eventz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Common
{
    public interface IEventProvider
    {
        string Type { get; }
        IEventsSource Source { get; }
        IEventsStorage Storage { get; }
    }

    public class EventProvider : IEventProvider
    {
        public string Type { get; set; }
        public IEventsSource Source { get; set; }
        public IEventsStorage Storage { get; set; }

        public EventProvider(string type, IEventsSource source, IEventsStorage storage)
        {
            this.Type = type;
            this.Source = source;
            this.Storage = storage;
        }

     
    }

}
