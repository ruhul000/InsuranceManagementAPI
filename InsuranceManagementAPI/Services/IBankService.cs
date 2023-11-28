using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllBanks();
        Task<Bank> GetBankById(int bankId);
        Task<Bank> Create(Bank bank, int userId);
        Task<Bank> Update(Bank bank, int userId);
        Task<bool> Delete(int bankId);
    }
}
