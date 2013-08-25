using Eventz.Data;
using Eventz.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.Interfaces
{
    public enum UpdateInterval
    {
        Today = 0,
        Closest,
        Week
    }

    public interface IEventsStorage
    {
        void SaveToDb(List<Event> events, UpdateInterval interval);
        IQueryable<Event> LoadFromDb();
        DateTime LastUpdated(UpdateInterval interval);
    }
}
