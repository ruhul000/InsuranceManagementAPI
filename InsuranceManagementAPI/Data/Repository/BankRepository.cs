using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly PolicyDBContext _context;

        public BankRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BankDto>> GetAllBanks()
        {
            return await _context.Bank.ToListAsync();
        }

        public async Task<BankDto> GetBankByID(long id)
        {
            return await _context.Bank.FirstOrDefaultAsync(obj => obj.BankId == id);
        }

        public async Task<bool> Add(BankDto bank)
        {
            _context.Bank.Add(bank);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
