using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

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
    }
}
