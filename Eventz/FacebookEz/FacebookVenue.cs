using Meetup.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meetup.FacebookEz
{
    public class FacebookVenue : BaseVenue
    {
        public static FacebookVenue Deserealize(dynamic venueObj)
        {
            FacebookVenue venue = new FacebookVenue();
            venue.Id = venueObj.id;
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
