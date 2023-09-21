using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IBranchFactory
    {
        IEnumerable<BranchDto> CreateMultipleFrom(IEnumerable<Branch> branch);
        IEnumerable<Branch> CreateMultipleFrom(IEnumerable<BranchDto> branchDto);

        Branch CreateFrom(BranchDto branchDto);
        BranchDto CreateFrom(Branch branch);
    }
}
