using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Data.Models;

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

        public async Task<IEnumerable<BankBranch>> GetBankBranches(int BankId)
        {
            var bankBranchDtos = await _bankBranchRepository.GetBankBranches(BankId);

            return _bankBranchFactory.CreateMultipleFrom(bankBranchDtos);
        }
        
        public async Task<BankBranch?> Create(BankBranch bankBranch)
        {
            BankBranch? response = null;
            var bankBranchDto = _bankBranchFactory.CreateFrom(bankBranch);

            try
            {
                var insertedId = _bankBranchRepository.Add(bankBranchDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                bankBranchDto = await _bankBranchRepository.GetBankBranchById(bankBranchDto.BranchId);

                response = _bankBranchFactory.CreateFrom(bankBranchDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public async Task<BankBranch> GetBankBranchById(int BranchId)
        {
            var bankBranchDto = await _bankBranchRepository.GetBankBranchById(BranchId);

            return _bankBranchFactory.CreateFrom(bankBranchDto);
        }

        public async Task<bool> Delete(int branchId)
        {
            var deleted = false;
            try
            {
                deleted = await _bankBranchRepository.Remove(branchId);
                if (deleted)
                {
                    return deleted;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return deleted;
        }

    }
}
