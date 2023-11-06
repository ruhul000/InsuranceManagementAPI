using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class CurrencyRepository: ICurrencyRepository
    {
        private readonly PolicyDBContext _context;

        public CurrencyRepository(PolicyDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(CurrencyDto currencyDto)
        {
            _context.Currency.Add(currencyDto);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CurrencyDto>> GetAll()
        {
            return await _context.Currency.ToListAsync();
        }

        public async Task<CurrencyDto> GetByID(int CurrencyKey)
        {
            return await _context.Currency.FirstOrDefaultAsync(obj => obj.CurrencyKey == CurrencyKey);
        }

        public async Task<bool> Update(CurrencyDto currencyDto)
        {

            _context.Currency.Attach(currencyDto);
            _context.Entry(currencyDto).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
