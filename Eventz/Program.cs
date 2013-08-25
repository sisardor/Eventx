using Meetup.ClubZone;
using Meetup.FacebookEz;
/*
 * Created by SharpDevelop.
 * User: Oleg
 * Date: 7/17/2013
 * Time: 11:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Http;

namespace Meetup
{
	class Program
	{
		public static void Main(string[] args)
		{
            FacebookService fbService = new FacebookService();
            fbService.GetEvents();
            //ClubZoneService czService = new ClubZoneService();
            //czService.GetEvents();
			//MeetupService meetupService = new MeetupService();
            //var events = meetupService.GetTopEvents(Locations.Vancouver, DateTime.Now);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}