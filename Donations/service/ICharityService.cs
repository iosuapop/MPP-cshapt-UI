using Donations.domain;

namespace Donations.service;

public interface ICharityService
{
    List<string> GetAllCase();
    Charity GetIdByCase(Charity charity);
}