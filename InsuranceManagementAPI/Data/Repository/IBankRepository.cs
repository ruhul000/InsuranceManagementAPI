using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankRepository
    {
        Task<IEnumerable<BankDto>> GetAllBanks();
        Task<BankDto> GetBankByID(long id);
        Task<bool> Add(BankDto bankDto);
        Task<bool> Update(BankDto bankDto);
        Task<bool> Remove(int bankId);
    }
}
