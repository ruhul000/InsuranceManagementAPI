using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int CompanyId);
        Task<Company> Create(Company company);
        Task<Company> Update(Company company);
        Task<bool> Delete(int CompanyId);
    }
}
