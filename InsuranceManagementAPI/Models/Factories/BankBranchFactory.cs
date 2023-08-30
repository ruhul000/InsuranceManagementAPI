using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class BankBranchFactory:IBankBranchFactory
    {
        IMappingFactory<BankBranch> _bankBranchFactory;
        IMappingFactory<BankBranchDto> _bankBranchDtoFactory;

        public BankBranchFactory(IMappingFactory<BankBranch> bankBranchFactory, IMappingFactory<BankBranchDto> bankBranchDtoFactory)
        {
            _bankBranchFactory = bankBranchFactory;
            _bankBranchDtoFactory = bankBranchDtoFactory;
        }
        public IEnumerable<BankBranchDto> CreateMultipleFrom(IEnumerable<BankBranch> BankBranch)
        {
            IEnumerable<BankBranchDto> response = _bankBranchDtoFactory.CreateMultipleFrom(BankBranch);
            return response;
        }

        public IEnumerable<BankBranch> CreateMultipleFrom(IEnumerable<BankBranchDto> BankBranchDtos)
        {
            IEnumerable<BankBranch> response = _bankBranchFactory.CreateMultipleFrom(BankBranchDtos);
            return response;
        }

        public BankBranch CreateFrom(BankBranchDto bankBranchDto)
        {
            return _bankBranchFactory.CreateFrom(bankBranchDto);
        }
        public BankBranchDto CreateFrom(BankBranch bankBranch)
        {
            return _bankBranchDtoFactory.CreateFrom(bankBranch);
        }
    }
}
