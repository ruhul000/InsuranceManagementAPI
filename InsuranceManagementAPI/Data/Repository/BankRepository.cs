using AutoMapper;
using InsuranceManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly PolicyDBContext _context;   
        private readonly IMapper _mapper;


        public BankRepository(PolicyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BankDto>> GetAllBanks()
        {
            return await _context.Bank.ToListAsync();
        }
    }
}
