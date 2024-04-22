using System.Security.Cryptography;
using System.Text;
using Donations.domain;
using Donations.repository;
using log4net;

namespace Donations.repository.implementations;

public class UserDbRepository : IUserRepository
{
    private static readonly ILog log = LogManager.GetLogger("UserDbRepository");

    IDictionary<String, string> props;

    public UserDbRepository(IDictionary<String, string> props)
    {
        log.Info("Creating UserDbRepository ");
        this.props = props;
    }

    public User FindOne(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> FindAll()
    {
        throw new NotImplementedException();
    }

    public int Save(User entity)
    {
        var con = DbUtils.getConnection(props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into User (username, password) values (@usr,@pass);";
            var paramName = comm.CreateParameter();
            paramName.ParameterName = "@usr";
            paramName.Value = entity.Name;
            comm.Parameters.Add(paramName);

            string encriptedPassword = EncryptPassword(entity.Password);
            var paramPassword = comm.CreateParameter();
            paramPassword.ParameterName = "@pass";
            paramPassword.Value = encriptedPassword;
            comm.Parameters.Add(paramPassword);

            int rowsAffected = comm.ExecuteNonQuery();
            if (rowsAffected <= 0)
                throw new RepositoryException("No user added !");
            comm.CommandText = "SELECT last_insert_rowid()";
            long  lastInsertedId = (long)comm.ExecuteScalar();
            int ressult = (int)lastInsertedId;
            return ressult;
        }
    }

    public void Delete(User id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, User entity)
    {
        throw new NotImplementedException();
    }

    public bool Login(string username, string password)
    {
        log.InfoFormat("Checking credentials for user {0}", username);
        string encryptedPassword = EncryptPassword(password);
        var connection = DbUtils.getConnection(props);
        using (var comm = connection.CreateCommand())
        {
            comm.CommandText = "select count(*) from User where username=@username and password=@password";
            var user = comm.CreateParameter();
            user.ParameterName = "@username";
            user.Value = username;
            comm.Parameters.Add(user);
            var pass = comm.CreateParameter();
            pass.ParameterName = "@password";
            pass.Value = encryptedPassword;
            comm.Parameters.Add(pass);
            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    var count = dataR.GetInt32(0);
                    log.InfoFormat("Found {0} users with username {1} and password", count, username);
                    return count > 0;
                }
            }
        }
        log.InfoFormat("No user found with username {0} and password", username);
        return false;
    }

    public static string EncryptPassword(string password)
    {
        try
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Encryption error: " + ex.Message);
            return null;
        }
    }
}