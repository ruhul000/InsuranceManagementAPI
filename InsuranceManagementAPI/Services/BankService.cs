using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Collections;
using System.ComponentModel;

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

        public async Task<Bank> GetBankById(int bankId)
        {
            var bankDto = await _bankRepository.GetBankByID(bankId);

            return _bankFactory.CreateFrom(bankDto);
        }

        public async Task<Bank?> Create(Bank bank, int userId)
        {
            Bank? response = null;
            var bankDto = _bankFactory.CreateFrom(bank);

            try
            {
                if (!_bankRepository.Add(bankDto, userId).Result)
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

        public async Task<Bank?> Update(Bank bank, int userId)
        {
            Bank? response = null;
            var bankDto = _bankFactory.CreateFrom(bank);

            try
            {
                var result = _bankRepository.Update(bankDto, userId).Result;
                if (!result)
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

        public async Task<bool> Delete(int bankId)
        {
            var deleted = false;
            try
            {
                deleted = await _bankRepository.Remove(bankId);
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
