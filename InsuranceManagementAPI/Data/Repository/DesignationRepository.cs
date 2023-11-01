using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly PolicyDBContext _context;

        public DesignationRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DesignationDto designationDto)
        {
            _context.Designation.Add(designationDto);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DesignationDto>> GetAll()
        {
            return await _context.Designation.ToListAsync();
        }

        public async Task<DesignationDto> GetByID(int degId)
        {
            return await _context.Designation.FirstOrDefaultAsync(obj => obj.DegKey == degId);
        }

        public async Task<bool> Update(DesignationDto designationDto)
        {
            _context.Designation.Attach(designationDto);
            _context.Entry(designationDto).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
