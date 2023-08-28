using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class BankBranchService: IBankBranchService
    {
        private readonly IBankBranchRepository _bankBranchRepository;
        private readonly IBankBranchFactory _bankBranchFactory;
        public BankBranchService(IBankBranchRepository bankBranchRepository, IBankBranchFactory bankBranchFactory)
        {
            _bankBranchRepository = bankBranchRepository;
            _bankBranchFactory = bankBranchFactory;
        }
        public async Task<IEnumerable<BankBranch>> GetAllBankBranches()
        {
            var bankBranchDtos = await _bankBranchRepository.GetAllBankBranches();

            return _bankBranchFactory.CreateMultipleFrom(bankBranchDtos);
        }


        public async Task<BankBranch?> Create(BankBranch bankBranch)
        {
            BankBranch? response = null;
            var bankBranchDto = _bankBranchFactory.CreateFrom(bankBranch);

            try
            {
                if (!_bankBranchRepository.Add(bankBranchDto).Result)
                {
                    return response;
                }

                bankBranchDto = await _bankBranchRepository.GetBankBranchByID(bankBranchDto.BranchId);

                response = _bankBranchFactory.CreateFrom(bankBranchDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

       
    }
}
