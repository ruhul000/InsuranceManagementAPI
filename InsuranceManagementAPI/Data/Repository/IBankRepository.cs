using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBanks();
    }
}
