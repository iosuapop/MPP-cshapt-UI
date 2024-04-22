using System.Data;
using Donations.domain;
using log4net;

namespace Donations.repository.implementations;

public class CharityDbRepository : ICharityRepository
{
    private static readonly ILog log = LogManager.GetLogger("CharityDbRepository");

    IDictionary<String, string> props;

    public CharityDbRepository(IDictionary<String, string> props)
    {
        log.Info("Creating CharityRepository ");
        this.props = props;
    }

    public Charity FindOne(int id)
    {
        throw new NotImplementedException();
    }

    public List<Charity> FindAll()
    {
        throw new NotImplementedException();
    }

    public int Save(Charity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Charity id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Charity entity)
    {
        throw new NotImplementedException();
    }

    public Charity GetIdByCharity(Charity charity)
    {
        log.InfoFormat("Entering GetIdByCharity with value {0}", charity.Description);
        IDbConnection con = DbUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT id FROM Charity WHERE description = @description";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@description";
            paramId.Value = charity.Description;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    int id = dataR.GetInt16(0);
                    Charity charity_new = new Charity(id, charity.Description);
                    log.InfoFormat("Exiting findOne with value {0}", charity_new);
                    return charity_new;
                }
            }
        }

        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public List<string> GetCases()
    {
        log.InfoFormat("Entering GetCases");
        IDbConnection con = DbUtils.getConnection(props);
        List<string> cases = new List<string>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT DISTINCT description FROM Charity";
            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                    cases.Add(dataR.GetString(0));
            }
        }
        log.InfoFormat("Found {0} distinct cases", cases.Count);
        return cases;
    }
}