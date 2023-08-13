using AutoMapper;
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
    }
}
