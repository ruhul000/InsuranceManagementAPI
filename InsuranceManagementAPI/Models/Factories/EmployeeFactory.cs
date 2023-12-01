using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        IMappingFactory<Employee> _employeeFactory;
        IMappingFactory<EmployeeDto> _employeeDtoFactory;

        public EmployeeFactory(IMappingFactory<Employee> employeeFactory, IMappingFactory<EmployeeDto> employeeDtoFactory)
        {
            _employeeFactory = employeeFactory;
            _employeeDtoFactory = employeeDtoFactory;
        }

        public Employee CreateFrom(EmployeeDto employeeDto)
        {
            Employee response = _employeeFactory.CreateFrom(employeeDto);
            return response;
        }

        public EmployeeDto CreateFrom(Employee employee)
        {
            EmployeeDto response = _employeeDtoFactory.CreateFrom(employee);
            return response;
        }

        public IEnumerable<EmployeeDto> CreateMultipleFrom(IEnumerable<Employee> employee)
        {
            IEnumerable<EmployeeDto> response = _employeeDtoFactory.CreateMultipleFrom(employee);
            return response;
        }

        public IEnumerable<Employee> CreateMultipleFrom(IEnumerable<EmployeeDto> employeeDto)
        {
            IEnumerable<Employee> response = _employeeFactory.CreateMultipleFrom(employeeDto);
            return response;
        }
    }
}
