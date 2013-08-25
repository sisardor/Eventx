using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventz.Services.FacebookEz
{
    public class FacebookRequests
    {
        public static string DateTimeFormat = "yyyy-MM-dd";

        public static string AccessToken = "CAACEdEose0cBALXtmXQBYzef3ySYaIz2ZCo6oiKARteX0OCMhX9oP4YjPvWOmnZCnGbZBkviyQXyrX2PlX26OMXnp6T7s1ZCxVGSFTIOe0m6xQoF3lxxUILZBo6esdiFIxzYAbX7T1SZBboau8c27RAHPMUN9tDPkBQDL4rEZBZBpgZDZD";

        public static string GetTopEvents = @"SELECT eid, name, start_time, timezone, venue, attending_count, description FROM event WHERE eid IN 
(SELECT eid FROM event_member WHERE uid = me())";

        public static string GetTopEventsRight = @"SELECT eid, name, start_time, timezone, venue, attending_count, description FROM event WHERE eid IN 
(SELECT eid FROM event_member WHERE uid = me() OR 
uid IN (SELECT uid2 FROM friend WHERE uid1 = me())) 
AND timezone = ""America/{0}"" 
AND start_time > ""{1}"" AND end_time < ""{2}"" 
ORDER by attending_count desc";


    }
}
