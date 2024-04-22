using Donations.domain;

namespace Donations.service;

public interface IDonorService
{
    Donor AddDonor(Donor donor);
    List<Donor> GetAllDonorsName(string name);
}