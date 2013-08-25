using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Model.Common
{
    public class Location
    {
        public Location(string country, string state, string city)
        {
            Country = country;
            State = state;
            City = city;
        }
        public string Country;
        public string State;
        public string City;
    }

    public static class Locations
    {
        public static Location Vancouver =
            new Location("Canada", "BC", "Vancouver");
    }
}
