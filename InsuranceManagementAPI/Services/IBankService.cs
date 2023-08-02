using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllBanks();
    }
}
