using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IInsuranceCompanyFactory
    {
        IEnumerable<InsurancebranchDto> CreateMultipleFrom(IEnumerable<InsuranceCompany> insuranceCompany);
        IEnumerable<InsuranceCompany> CreateMultipleFrom(IEnumerable<InsurancebranchDto> insurancebranchDto);

        InsuranceCompany CreateFrom(InsurancebranchDto insurancebranchDto);
        InsurancebranchDto CreateFrom(InsuranceCompany insuranceCompany);
    }
}
