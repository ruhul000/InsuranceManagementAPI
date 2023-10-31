using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class DepartmentFactory : IDepartmentFactory
    {
        IMappingFactory<Department> _departmentFactory;
        IMappingFactory<DepartmentDto> _departmentDtoFactory;

        public DepartmentFactory(IMappingFactory<Department> departmentFactory, IMappingFactory<DepartmentDto> departmentDtoFactory)
        {
            _departmentFactory = departmentFactory;
            _departmentDtoFactory = departmentDtoFactory;
        }

        public Department CreateFrom(DepartmentDto departmentDto)
        {
            Department response = _departmentFactory.CreateFrom(departmentDto);
            return response;
        }

        public DepartmentDto CreateFrom(Department department)
        {
            DepartmentDto response = _departmentDtoFactory.CreateFrom(department);
            return response;
        }

        public IEnumerable<DepartmentDto> CreateMultipleFrom(IEnumerable<Department> department)
        {
            IEnumerable<DepartmentDto> response = _departmentDtoFactory.CreateMultipleFrom(department);
            return response;
        }

        public IEnumerable<Department> CreateMultipleFrom(IEnumerable<DepartmentDto> departmentDto)
        {
            IEnumerable<Department> response = _departmentFactory.CreateMultipleFrom(departmentDto);
            return response;
        }
    }
}
