using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllBanks();
        Task<Bank> GetBankById(int bankId);
        Task<Bank> Create(Bank bank);
        Task<Bank> Update(Bank bank);
        Task<bool> Delete(int bankId);
    }
}
