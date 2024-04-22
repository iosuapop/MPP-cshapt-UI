using Donations.domain;

namespace Donations.service;

public interface IDonationService
{
    List<Tuple<Charity, float>> GetCharityFunds();
}