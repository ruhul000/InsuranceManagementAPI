using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankBranchRepository:IBankBranchRepository
    {
        private readonly PolicyDBContext _context;

        public BankBranchRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BankBranchDto>> GetAllBankBranches()
        {
            return await _context.BankBranch.ToListAsync();
        }

        public async Task<BankBranchDto> GetBankBranchByID(long id)
        {
            return await _context.BankBranch.FirstOrDefaultAsync(obj => obj.BranchId == id);
        }

        public async Task<bool> Add(BankBranchDto bankBranch)
        {
            _context.BankBranch.Add(bankBranch);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
