using log4net;
using log4net.Config;

using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Donations.domain;
using Donations.repository.implementations;

namespace Donations
{
	class MainClass
	{
		public static void FirstMain(string[] args)
		{
			//configurare jurnalizare folosind log4net
			XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
			//Console.WriteLine("Configuration Settings for donationDB {0}",GetConnectionStringByName("donationDB"));
			IDictionary<String, string> props = new SortedList<String, String>();
			props.Add("ConnectionString", GetConnectionStringByName("donationDB"));

			Console.WriteLine("Donation Repository DB ...");
			DonationDbRepository donationRepo = new DonationDbRepository(props);

			Console.WriteLine("Donatiile din db");
			foreach (Donation d in donationRepo.FindAll())
			{
				Console.WriteLine(d);
			}

			Debug.Assert(donationRepo.FindAll().Count == 5, "sunt 5 donatii facute momentan");

			Console.WriteLine("Suma si caritate din db");
			foreach (Tuple<Charity, float> a in donationRepo.GetCharityAmounts())
			{
				Console.WriteLine(a);
			}

			UserDbRepository userRepo = new UserDbRepository(props);

			// Debug.Assert(userRepo.Login("iosua","pop") == false, "nu exista acest cont");
			//
			// userRepo.Save(new User(0, "iosua", "pop"));
			Debug.Assert(userRepo.Login("iosua", "pop") == true, "exista acest cont");

			CharityDbRepository charityRepo = new CharityDbRepository(props);

			Console.WriteLine("Cazuri caritabile din db");
			foreach (string s in charityRepo.GetCases())
			{
				Console.WriteLine(s);
			}

			Debug.Assert(charityRepo.GetCases().Count == 3, "sunt 3 caritati momentan");

			Debug.Assert(
				charityRepo.GetIdByCharity(new Charity(0, "Razboi Ukraina")).Id == 2 &&
				charityRepo.GetIdByCharity(new Charity(0, "Razboi Ukraina")).Description == "Razboi Ukraina",
				"are id 2 si descriere");
			Console.WriteLine(charityRepo.GetIdByCharity(new Charity(0, "Razboi Ukraina")));
			DonorDbRepository donorRepo = new DonorDbRepository(props);

			foreach (Donor d in donorRepo.GetDonorName(""))
			{
				Console.WriteLine(d);
			}

			Debug.Assert(donorRepo.GetDonorName("").Count == 4, "sunt 4 donatori momentan");

			Debug.Assert(donorRepo.GetDonorName("an").Count == 2, "sunt 2 donatori momentan cu an in nume");

			Debug.Assert(
				donorRepo.GetDonorById(new Donor(0, "Vlad", "0734592188", "Romania, Cluj Napoca, strada Borsec")) == 4);
		}


		static string GetConnectionStringByName(string name)
		{
			// Assume failure.
			string returnValue = null;

			// Look for the name in the connectionStrings section.
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

			// If found, return the connection string.
			if (settings != null)
				returnValue = settings.ConnectionString;

			return returnValue;
		}
	}
}