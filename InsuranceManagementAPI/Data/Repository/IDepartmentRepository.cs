using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<DepartmentDto> GetByID(int depId);
        Task<int> Add(DepartmentDto departmentDto);
        Task<bool> Update(DepartmentDto departmentDto);
    }
}
