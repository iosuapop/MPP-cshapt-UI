using Donations.domain;

namespace Donations.repository;

public interface IDonationRepository : IRepository<Donation, int>
{
    List<Tuple<Charity, float>> GetCharityAmounts();
}