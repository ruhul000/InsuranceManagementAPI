using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankBranchService
    {
        Task<IEnumerable<BankBranch>> GetAllBankBranches();
        Task<BankBranch> Create(BankBranch bankBranch);
    }
}
