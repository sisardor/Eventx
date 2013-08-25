using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meetup.FacebookEz
{
    public class FacebookRequests
    {
        public static string GetTopEvents = @"SELECT eid, name, start_time, timezone, venue, attending_count FROM event WHERE eid IN 
(SELECT eid FROM event_member WHERE uid = me() OR 
uid IN (SELECT uid2 FROM friend WHERE uid1 = me())) 
AND timezone = ""America/{0}"" 
AND start_time > ""{1}"" AND start_time < ""{2}"" 
ORDER by attending_count desc";

    }
}
