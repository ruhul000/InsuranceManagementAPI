using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankBranchService
    {
        Task<IEnumerable<BankBranch>> GetAllBankBranches();
        Task<IEnumerable<BankBranch>> GetBankBranches(int BankId);
        Task<BankBranch> GetBankBranchById(int BranchId);
        Task<BankBranch> Create(BankBranch bankBranch);
        Task<BankBranch> Update(BankBranch bankBranch);
        Task<bool> Delete(int branchId);
    }
}
