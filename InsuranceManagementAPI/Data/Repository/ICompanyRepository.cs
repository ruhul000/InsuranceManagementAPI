using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllBanks();
        Task<CompanyDto> GetBankByID(int companyId);
        Task<Int32> Add(CompanyDto bankDto);
        Task<bool> Update(CompanyDto bankDto);
        Task<bool> Remove(int companyId);

    }
}
