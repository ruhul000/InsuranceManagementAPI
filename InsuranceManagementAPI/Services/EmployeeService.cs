using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }
        public async Task<Employee> Create(Employee employee)
        {
            Employee? response = null;
            var employeeDto =  _employeeFactory.CreateFrom(employee);

            try
            {
                var insertedId =  _employeeRepository.Add(employeeDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }


                //employeeDto.DepKey = insertedId;

                response = _employeeFactory.CreateFrom(employeeDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int DepId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employeeDtos = await _employeeRepository.GetAll();

            return _employeeFactory.CreateMultipleFrom(employeeDtos);
        }

        public async Task<Employee> GetById(int DepId)
        {
            var employeeDto = await _employeeRepository.GetByID(DepId);

            return _employeeFactory.CreateFrom(employeeDto);
        }

        public Task<Employee> Update(Employee employee)
        {
            Employee? response = null;
            var employeeDto = _employeeFactory.CreateFrom(employee);

            try
            {
                var result = _employeeRepository.Update(employeeDto).Result;
                if (!result)
                {
                    return Task.FromResult<Employee>(response);
                }



                response = _employeeFactory.CreateFrom(employeeDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Employee>(response);
            }

            return Task.FromResult(response);

        }
    }
}
