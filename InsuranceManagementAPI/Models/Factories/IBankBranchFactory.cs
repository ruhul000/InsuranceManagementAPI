using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IBankBranchFactory
    {
        IEnumerable<BankBranchDto> CreateMultipleFrom(IEnumerable<BankBranch> BankBranch);
        IEnumerable<BankBranch> CreateMultipleFrom(IEnumerable<BankBranchDto> BankBranchDtos);

        BankBranch CreateFrom(BankBranchDto bankBranchDto);
        BankBranchDto CreateFrom(BankBranch bankBranch);
    }
}
