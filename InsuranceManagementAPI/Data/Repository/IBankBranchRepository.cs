using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankBranchRepository
    {
        Task<IEnumerable<BankBranchDto>> GetAllBankBranches(BankBranchDto bankBranchDto);    
        Task<int> Add(BankBranchDto bankBranchDto);
        Task<IEnumerable<BankBranchDto>> GetBankBranches(int bankId);
        Task<BankBranchDto> GetBankBranchById(int branchId);
        Task<bool> Update(BankBranchDto bankBranchDto);
        Task<bool> Remove(int branchId);

    }
}
