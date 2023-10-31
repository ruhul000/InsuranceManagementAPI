using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IDepartmentFactory
    {
        IEnumerable<DepartmentDto> CreateMultipleFrom(IEnumerable<Department> department);
        IEnumerable<Department> CreateMultipleFrom(IEnumerable<DepartmentDto> departmentDto);

        Department CreateFrom(DepartmentDto departmentDto);
        DepartmentDto CreateFrom(Department department);
    }
}
