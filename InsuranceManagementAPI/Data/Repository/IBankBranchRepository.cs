using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankBranchRepository
    {
        Task<IEnumerable<BankBranchDto>> GetAllBankBranches();
        Task<BankBranchDto> GetBankBranchByID(long id);
        Task<bool> Add(BankBranchDto bankBranchDto);
    }
}
