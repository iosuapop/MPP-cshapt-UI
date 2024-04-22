using Donations.domain;
using Donations.repository;
using Donations.repository.implementations;

namespace Donations.service;

public class Service : IService
{
    private readonly ICharityRepository charityRepository;
    private readonly IDonationRepository donationRepository;
    private readonly IDonorRepository donorRepository;
    private readonly IUserRepository userRepository;

    public Service(IDictionary<string, string> props)
    {
        donorRepository = new DonorDbRepository(props);
        donationRepository = new DonationDbRepository(props);
        charityRepository = new CharityDbRepository(props);
        userRepository = new UserDbRepository(props);
    }

    public List<Tuple<Charity, float>> GetCharityFunds()
    {
        return donationRepository.GetCharityAmounts();
    }

    public Donor AddDonor(Donor donor)
    {
        var donorId = donorRepository.GetDonorById(donor);
        if (donorId > 0)
        {
            donor.Id = donorId;
            return donor;
        }

        donor.Id = donorRepository.Save(donor);
        return donor;
    }

    public List<Donor> GetAllDonorsName(string name)
    {
        return donorRepository.GetDonorName(name);
    }

    public int GetSize()
    {
        throw new NotImplementedException();
    }

    public bool Login(string username, string password)
    {
        return userRepository.Login(username, password);
    }

    public List<string> GetAllCase()
    {
        return charityRepository.GetCases();
    }

    public Charity GetIdByCase(Charity charity)
    {
        return charityRepository.GetIdByCharity(charity);
    }

    public Donation AddDonation(Donation donation)
    {
        /*if (donation.Amount < 0)
            throw new Exception("Can't donate negative balance!");*/

        donation.Id = donationRepository.Save(donation);
        return donation;
    }
}