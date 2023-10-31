using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int DepId);
        Task<Department> Create(Department department);
        Task<Department> Update(Department department);
        Task<bool> Delete(int DepId);
    }
}
