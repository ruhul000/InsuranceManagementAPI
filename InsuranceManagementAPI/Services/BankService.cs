using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            return await _bankRepository.GetAllBanks();
        }
    }
}
