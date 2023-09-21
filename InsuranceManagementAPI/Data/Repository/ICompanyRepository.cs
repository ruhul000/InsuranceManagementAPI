using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAll();
        Task<CompanyDto> GetByID(int companyId);
        Task<Int32> Add(CompanyDto companyDto);
        Task<bool> Update(CompanyDto companyDto);
        Task<bool> Remove(int companyId);

    }
}
