using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PolicyDBContext _context;

        public DepartmentRepository(PolicyDBContext context) 
        {
            _context = context;
        }
        public async Task<int> Add(DepartmentDto departmentDto)
        {
            _context.Department.Add(departmentDto);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<DepartmentDto> GetByID(int depId)
        {
            return await _context.Department.FirstOrDefaultAsync(obj => obj.DepKey == depId);
        }

        public Task<bool> Remove(int depId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(DepartmentDto departmentDto)
        {            
            _context.Entry(departmentDto).State = EntityState.Modified;
            _context.Department.Add(departmentDto);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
