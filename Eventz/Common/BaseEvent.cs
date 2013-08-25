using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventz.Common
{
    public class BaseEvent
    {
        public Int64 Id;
		public string Name;
		public DateTime StartTime;
		public string Description;
		public BaseVenue Venue;
		public string EventUrl;
		public int AttendingCount;
    }
}
