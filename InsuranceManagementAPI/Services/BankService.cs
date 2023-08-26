using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Collections;

namespace InsuranceManagementAPI.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IBankFactory _bankFactory;
        public BankService(IBankRepository bankRepository, IBankFactory bankFactory)
        {
            _bankRepository = bankRepository;
            _bankFactory = bankFactory;
        }
        public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            var bankDtos = await _bankRepository.GetAllBanks();

            return _bankFactory.CreateMultipleFrom(bankDtos);
        }

        
        public async Task<Bank?> Create(Bank bank)
        {
            Bank? response = null;
            var bankDto = _bankFactory.CreateFrom(bank);

            try
            {
                if (!_bankRepository.Add(bankDto).Result)
                {
                    return response;
                }

                bankDto = await _bankRepository.GetBankByID(bankDto.BankId);

                response = _bankFactory.CreateFrom(bankDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
    }
}
