using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceManagementAPI.Models.Factories
{
    public class BranchFactory : IBranchFactory
    {
        IMappingFactory<Branch> _branchFactory;
        IMappingFactory<BranchDto> _branchDtoFactory;

        public BranchFactory(IMappingFactory<Branch> branchFactory, IMappingFactory<BranchDto> branchDtoFactory)
        {
            _branchFactory = branchFactory;
            _branchDtoFactory = branchDtoFactory;
        }

        public Branch CreateFrom(BranchDto branchDto)
        {
            Branch response = _branchFactory.CreateFrom(branchDto);
            return response;
        }

        public BranchDto CreateFrom(Branch branch)
        {
            BranchDto response = _branchDtoFactory.CreateFrom(branch);
            return response;
        }

        public IEnumerable<BranchDto> CreateMultipleFrom(IEnumerable<Branch> branch)
        {
            IEnumerable<BranchDto> response = _branchDtoFactory.CreateMultipleFrom(branch);
            return response;
        }

        public IEnumerable<Branch> CreateMultipleFrom(IEnumerable<BranchDto> branchDto)
        {
            IEnumerable<Branch> response = _branchFactory.CreateMultipleFrom(branchDto);
            return response;
        }
    }
}
