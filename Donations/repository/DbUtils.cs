using System.Data;
using ConnectionUtils;

namespace Donations.repository;

public static class DbUtils
{
    private static IDbConnection instance;


    public static IDbConnection getConnection(IDictionary<string, string> props)
    {
        if (instance == null || instance.State == ConnectionState.Closed)
        {
            instance = getNewConnection(props);
            instance.Open();
        }

        return instance;
    }

    private static IDbConnection getNewConnection(IDictionary<string, string> props)
    {
        return ConnectionFactory.getInstance().createConnection(props);
    }
}