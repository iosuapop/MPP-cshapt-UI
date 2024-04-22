using Donations.domain;

namespace Donations.repository;

public interface ICharityRepository : IRepository<Charity, int>
{
    Charity GetIdByCharity(Charity charity);
    List<string> GetCases();
}