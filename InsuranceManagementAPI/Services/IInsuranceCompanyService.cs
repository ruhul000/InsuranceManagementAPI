using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IInsuranceCompanyService
    {
        Task<IEnumerable<InsuranceCompany>> GetAll();
        Task<InsuranceCompany> GetById(int CompanyId);
        Task<InsuranceCompany> Create(InsuranceCompany insuranceCompany);
        Task<InsuranceCompany> Update(InsuranceCompany insuranceCompany);
        Task<bool> Delete(int CompanyId);
    }
}
