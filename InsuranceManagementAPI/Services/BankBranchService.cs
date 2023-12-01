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
        public async Task<IEnumerable<BankBranch>> GetAllBankBranches(BankBranch bankBranch)
        {
            BankBranchDto bankBranchDto = _bankBranchFactory.CreateFrom(bankBranch);
            var bankBranchDtos = await _bankBranchRepository.GetAllBankBranches(bankBranchDto);

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
                if (bankBranch.BankId == 0 || bankBranch.BranchName == "")
                {
                    return response;
                }
                var insertedId = _bankBranchRepository.Add(bankBranchDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                //bankBranchDto = await _bankBranchRepository.GetBankBranchById(bankBranchDto.BranchId);
                bankBranchDto.BranchId = insertedId;

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

        public async Task<BankBranch?> Update(BankBranch bankBranch)
        {
            BankBranch? response = null;
            var bankBranchDto = _bankBranchFactory.CreateFrom(bankBranch);

            try
            {
                var result = _bankBranchRepository.Update(bankBranchDto).Result;
                if (!result)
                {
                    return response;
                }

                //bankBranchDto = await _bankBranchRepository.GetBankBranchByID(bankDto.BankId);

                response = _bankBranchFactory.CreateFrom(bankBranchDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
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
