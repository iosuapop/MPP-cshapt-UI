using System.Data;
using System.Data.SqlClient;
using Donations.domain;
using log4net;

namespace Donations.repository.implementations;

public class DonationDbRepository : IDonationRepository
{
    private static readonly ILog log = LogManager.GetLogger("DonationDbRepository");

    IDictionary<String, string> props;

    public DonationDbRepository(IDictionary<String, string> props)
    {
        log.Info("Creating DonationDbRepository ");
        this.props = props;
    }
    
    public Donation FindOne(int id)
    {
        throw new NotImplementedException();
    }

    public List<Donation> FindAll()
    {
        var donations = new List<Donation>();
        
        log.InfoFormat("Entering FindAll");
        IDbConnection con = DbUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT do.*,d.*, c.* FROM Donation do INNER JOIN Donor d ON do.id_donor = d.id INNER JOIN Charity c ON do.id_charity = c.id"; 
            using (var reader = comm.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    int id_donor = reader.GetInt32(reader.GetOrdinal("id_donor"));
                    int id_charity = reader.GetInt32(reader.GetOrdinal("id_charity"));
                    float amount = reader.GetFloat(reader.GetOrdinal("amount"));
                    string name = reader.GetString(reader.GetOrdinal("name"));
                    string telephone = reader.GetString(reader.GetOrdinal("telephone"));
                    string address = reader.GetString(reader.GetOrdinal("adress"));
                    string description = reader.GetString(reader.GetOrdinal("description"));

                    var charity = new Charity(id_charity, description);
                    var donor = new Donor(id_donor, name, telephone, address);
                    var donation = new Donation(id, charity, donor, amount);

                    donations.Add(donation);
                }
            }
        } 
        return donations;
    }
    
    public int Save(Donation entity)
    {
        log.InfoFormat("Saving donation for charity {0} from donor {1} with amount {2}", entity.Charity.Description, entity.Donor.Name, entity.Amount);
        var dbConnection = DbUtils.getConnection(props);
        using (var com = dbConnection.CreateCommand())
        {
            com.CommandText =
                "INSERT INTO Donation (id_charity, id_donor, amount) VALUES (@charity_id, @donor_id, @amount) RETURNING id";
            var charityIdParam = com.CreateParameter();
            charityIdParam.ParameterName = "@charity_id";
            charityIdParam.Value = entity.Charity.Id;
            com.Parameters.Add(charityIdParam);

            var donorIdParam = com.CreateParameter();
            donorIdParam.ParameterName = "@donor_id";
            donorIdParam.Value = entity.Donor.Id;
            com.Parameters.Add(donorIdParam);

            var amountParam = com.CreateParameter();
            amountParam.ParameterName = "@amount";
            amountParam.Value = entity.Amount;
            com.Parameters.Add(amountParam);

            var ret = Convert.ToInt32(com.ExecuteScalar());
            if (ret <= 0)
            {
                log.Info("No donation was added");
                return -1;
            }
            
            log.InfoFormat("Donation for charity {0} from donor {1} with amount {2} was added with ID {3}", entity.Charity.Description, entity.Donor.Name, entity.Amount, ret);
            return ret;
        } 
    }

    public void Delete(Donation id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Donation entity)
    {
        throw new NotImplementedException();
    }

    public List<Tuple<Charity, float>> GetCharityAmounts()
    {
        log.Info("Getting amounts donated to each charity");
        var charityAmounts = new List<Tuple<Charity, float>>();
        var connection = DbUtils.getConnection(props);
        using (var com = connection.CreateCommand())
        {
            com.CommandText = "SELECT c.*, SUM(do.amount) AS total_amount FROM Charity c LEFT JOIN Donation do ON c.id = do.id_charity GROUP BY c.id";
            using (var dataR = com.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int charityId = dataR.GetInt32(0);
                    string description = dataR.GetString(1);
                    float amount = dataR.GetFloat(2);
                    Charity charity = new Charity(charityId, description);
                    charityAmounts.Add(new Tuple<Charity, float>(charity, amount));
                }
            }
        }
        log.InfoFormat("Found amounts for {0} charities", charityAmounts.Count);
        return charityAmounts;
    }
}