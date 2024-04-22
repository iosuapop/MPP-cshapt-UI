using Donations.domain;

namespace Donations.repository;

public interface IDonorRepository : IRepository<Donor, int>
{
    List<Donor> GetDonorName(string name);

    int GetDonorById(Donor donor);
}