using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<IEnumerable<EmployeeDto>> GetAllByName(String EmployeeName);
        Task<EmployeeDto> GetByID(int id);
        Task<int> Add(EmployeeDto employeeDto);
        Task<bool> Update(EmployeeDto employee);
    }
}
