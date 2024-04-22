using Donations.domain;

namespace Donations.repository;

internal interface IUserRepository : IRepository<User, int>
{
    bool Login(string username, string password);
}