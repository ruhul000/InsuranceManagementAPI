using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IInsuranceCompanyRepository
    {
        Task<IEnumerable<InsuranceCompanyDto>> GetAll();
        Task<InsuranceCompanyDto> GetByID(int id);
        Task<Int32> Add(InsuranceCompanyDto insuranceCompanyDto);
        Task<bool> Update(InsuranceCompanyDto insuranceCompanyDto);
        Task<bool> Remove(int companyId);
    }
}
