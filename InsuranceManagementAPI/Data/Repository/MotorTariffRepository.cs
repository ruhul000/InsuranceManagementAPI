using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class MotorTariffRepository: IMotorTariffRepository
    {
        private readonly PolicyDBContext _context;

        public MotorTariffRepository(PolicyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MotorTariffDto>> GetAll()
        {
            return await _context.MotorTariff.ToListAsync();
        }
    }
}
