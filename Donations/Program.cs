using System.Configuration;
using Donations.repository.implementations;
using Donations.service;
using log4net.Config;

namespace Donations;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        
        XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
        //Console.WriteLine("Configuration Settings for donationDB {0}",GetConnectionStringByName("donationDB"));
        IDictionary<String, string> props = new SortedList<String, String>();
        props.Add("ConnectionString", GetConnectionStringByName("donationDB"));

        // UserDbRepository userRepo = new UserDbRepository(props);
        // CharityDbRepository charityRepo = new CharityDbRepository(props);
        // DonorDbRepository donorRepo = new DonorDbRepository(props);
        // DonationDbRepository donationsRepo = new DonationDbRepository(props);

        Service service = new Service(props);
        
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginView(service));
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
