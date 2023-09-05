using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IInsuranceCompanyFactory
    {
        IEnumerable<InsuranceCompanyDto> CreateMultipleFrom(IEnumerable<InsuranceCompany> insuranceCompany);
        IEnumerable<InsuranceCompany> CreateMultipleFrom(IEnumerable<InsuranceCompanyDto> insuranceCompanyDto);

        InsuranceCompany CreateFrom(InsuranceCompanyDto insuranceCompanyDto);
        InsuranceCompanyDto CreateFrom(InsuranceCompany insuranceCompany);
    }
}
