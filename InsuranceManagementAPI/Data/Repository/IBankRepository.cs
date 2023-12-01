using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankRepository
    {
        Task<IEnumerable<BankDto>> GetAllBanks();
        Task<BankDto> GetBankByID(long id);
        Task<bool> Add(BankDto bankDto, int userId);
        Task<bool> Update(BankDto bankDto, int userId);
        Task<bool> Remove(int bankId);
    }
}
