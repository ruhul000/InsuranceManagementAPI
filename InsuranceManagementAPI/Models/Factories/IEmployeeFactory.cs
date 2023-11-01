using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IEmployeeFactory
    {
        IEnumerable<EmployeeDto> CreateMultipleFrom(IEnumerable<Employee> employee);
        IEnumerable<Employee> CreateMultipleFrom(IEnumerable<EmployeeDto> employeeDto);

        Employee CreateFrom(EmployeeDto employeeDto);
        EmployeeDto CreateFrom(Employee employee);
    }
}
