using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int EmpKey);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int EmpKey);
    }
}
