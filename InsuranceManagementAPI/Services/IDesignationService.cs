using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IDesignationService
    {
        Task<IEnumerable<Designation>> GetAll();
        Task<Designation> GetById(int DepId);
        Task<Designation> Create(Designation designation);
        Task<Designation> Update(Designation designation);
        Task<bool> Delete(int DepId);
    }
}
