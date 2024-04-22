using Donations.domain;
using log4net;

namespace Donations.repository.implementations;

public class DonorDbRepository : IDonorRepository
{
    private static readonly ILog log = LogManager.GetLogger("DonorDbRepository");

    IDictionary<String, string> props;
    public DonorDbRepository(IDictionary<String, string> props)
    {
        log.Info("Creating DonorDbRepository ");
        this.props = props;
    }
    
    public Donor FindOne(int id)
    {
        throw new NotImplementedException();
    }

    public List<Donor> FindAll()
    {
        throw new NotImplementedException();
    }

    public int Save(Donor entity)
    {
        log.InfoFormat("Adding donor {0}", entity.Name);
        var dbConnection = DbUtils.getConnection(props);
        using (var com = dbConnection.CreateCommand())
        {
            com.CommandText = "insert into Donor (name, telephone, adress) values (@name, @telephone, @adress) RETURNING id";
            var paramName = com.CreateParameter();
            paramName.ParameterName = "@name";
            paramName.Value = entity.Name;
            com.Parameters.Add(paramName);

            var paramTelephone = com.CreateParameter();
            paramTelephone.ParameterName = "@telephone";
            paramTelephone.Value = entity.Telephone;
            com.Parameters.Add(paramTelephone);

            var paramAddress = com.CreateParameter();
            paramAddress.ParameterName = "@adress";
            paramAddress.Value = entity.Address;
            com.Parameters.Add(paramAddress);

            int ret = Convert.ToInt32(com.ExecuteScalar());
            if (ret <= 0)
            {
                log.InfoFormat("No donor was added");
                return -1;
            }

            log.InfoFormat("Donor {0} was added", entity.Name);
            return Convert.ToInt32(ret);
        }
    }

    public void Delete(Donor id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Donor entity)
    {
        throw new NotImplementedException();
    }

    public List<Donor> GetDonorName(string name)
    {
        log.InfoFormat("Getting donors with name containing {0}", name);
        var donors = new List<Donor>();
        var connection = DbUtils.getConnection(props);
        using (var com = connection.CreateCommand())
        {
            com.CommandText = "SELECT * FROM Donor WHERE name LIKE @name";
            var paramName = com.CreateParameter();
            paramName.ParameterName = "@name";
            paramName.Value = "%" + name + "%";
            com.Parameters.Add(paramName);
            using (var dataR = com.ExecuteReader())
            {
                while (dataR.Read())
                {
                    var id = dataR.GetInt32(0);
                    var donorName = dataR.GetString(1);
                    var telephone = dataR.GetString(2);
                    var address = dataR.GetString(3);
                    donors.Add(new Donor(id, donorName, telephone, address));
                }
            }
        }
        log.InfoFormat("Found {0} donors with name containing {1}", donors.Count, name);
        return donors;
    }

    public int GetDonorById(Donor donor)
    {
        log.InfoFormat("Getting donor ID for {0}", donor);
        var connection = DbUtils.getConnection(props);
        using (var com = connection.CreateCommand())
        {
            com.CommandText = "SELECT id FROM Donor WHERE name = @name AND telephone = @telephone AND adress = @adress";
            var paramName = com.CreateParameter();
            paramName.ParameterName = "@name";
            paramName.Value = donor.Name;
            com.Parameters.Add(paramName);

            var paramTelephone = com.CreateParameter();
            paramTelephone.ParameterName = "@telephone";
            paramTelephone.Value = donor.Telephone;
            com.Parameters.Add(paramTelephone);

            var paramAdress = com.CreateParameter();
            paramAdress.ParameterName = "@adress";
            paramAdress.Value = donor.Address;
            com.Parameters.Add(paramAdress);

            int ret = Convert.ToInt32(com.ExecuteScalar());
            if (ret <= 0)
            {
                log.InfoFormat("No donor found");
                return -1;
            }

            log.InfoFormat("Found donor ID {0} for {1}", ret, donor);
            return Convert.ToInt32(ret);
        }
    }
}