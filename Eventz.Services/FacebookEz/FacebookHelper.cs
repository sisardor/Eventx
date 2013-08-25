using Eventz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services.FacebookEz
{
    public partial class FacebookHelper
    {
        public static Venue DeserealizeVenue(dynamic venueObj)
        {
            Venue venue = new Venue();
            venue.Lat = venueObj.latitude;
            venue.Lon = venueObj.longitude;
            venue.City = venueObj.city;
            venue.State = venueObj.state;
            venue.Country = venueObj.country;
            venue.Street = venueObj.street;
            venue.Zip = venueObj.zip;

            return venue;
        }
    }
}
