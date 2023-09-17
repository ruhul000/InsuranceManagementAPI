using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface ICompanyFactory
    {
        IEnumerable<CompanyDto> CreateMultipleFrom(IEnumerable<Company> company);
        IEnumerable<Company> CreateMultipleFrom(IEnumerable<CompanyDto> companyDto);

        Company CreateFrom(CompanyDto companyDto);
        CompanyDto CreateFrom(Company company);
    }
}
