using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<IEnumerable<EmployeeDto>> GetAllByName(String EmployeeName);
        Task<EmployeeDto> GetByID(long id);
        Task<long> Add(EmployeeDto employeeDto);
        Task<bool> Update(EmployeeDto employee);
    }
}
