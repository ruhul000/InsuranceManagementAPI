using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace InsuranceManagementAPI.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PolicyDBContext _context;

        public EmployeeRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            //return await _context.Employees.Where(p => p.EmployeeName.StartsWith("As")).ToListAsync().Take(10);
            return await _context.Employee.Take(50).OrderBy(c => c.EmpName).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllByName(String EmpName)
        {
            if (EmpName.StartsWith("%"))
            {
                EmpName = EmpName.Substring(1, EmpName.Length - 1);
                return await _context.Employee.Where(c => c.EmpName.Contains(EmpName)).OrderBy(c => c.EmpName).Take(50).ToListAsync();
            }
            else
            {
                return await _context.Employee.Where(c => c.EmpName.StartsWith(EmpName)).OrderBy(c => c.EmpName).Take(50).ToListAsync();
            }

        }


        public async Task<EmployeeDto> GetByID(int id)
        {
            return await _context.Employee.FirstOrDefaultAsync(obj => obj.EmpKey == id);
        }
        public async Task<int> Add(EmployeeDto employeeDto)
        {
            _context.Employee.Add(employeeDto);
            var result = await _context.SaveChangesAsync();
            return (result);            
        }

        public async Task<bool> Update(EmployeeDto employeeDto)
        {
            _context.Employee.Attach(employeeDto);
            _context.Entry(employeeDto).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);

        }

        public async Task<bool> Remove(int employeeKey)
        {
            EmployeeDto employeeDto = new EmployeeDto { EmpKey = employeeKey };
            _context.Employee.Remove(employeeDto);

            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
