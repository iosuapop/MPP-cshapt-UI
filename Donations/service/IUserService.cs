using Donations.domain;

namespace Donations.service;

public interface IUserService
{
    bool Login(string username, string password);
}