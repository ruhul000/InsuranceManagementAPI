using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class InsuranceCompanyFactory: IInsuranceCompanyFactory
    {
        IMappingFactory<InsuranceCompany> _insuranceCompanyFactory;
        IMappingFactory<InsuranceCompanyDto> _insuranceCompanyDtoFactory;

        public InsuranceCompanyFactory(IMappingFactory<InsuranceCompany> insuranceCompanyFactory, IMappingFactory<InsuranceCompanyDto> insuranceCompanyDtoFactory)
        {
            _insuranceCompanyFactory = insuranceCompanyFactory;
            _insuranceCompanyDtoFactory = insuranceCompanyDtoFactory;
        }

        public InsuranceCompany CreateFrom(InsuranceCompanyDto insuranceCompanyDto)
        {
            return _insuranceCompanyFactory.CreateFrom(insuranceCompanyDto);
        }

        public InsuranceCompanyDto CreateFrom(InsuranceCompany insuranceCompany)
        {
            return _insuranceCompanyDtoFactory.CreateFrom(insuranceCompany);
        }

        public IEnumerable<InsuranceCompanyDto> CreateMultipleFrom(IEnumerable<InsuranceCompany> insuranceCompany)
        {
            IEnumerable<InsuranceCompanyDto> response = _insuranceCompanyDtoFactory.CreateMultipleFrom(insuranceCompany);
            return response;
        }

        public IEnumerable<InsuranceCompany> CreateMultipleFrom(IEnumerable<InsuranceCompanyDto> insuranceCompanyDto)
        {
            IEnumerable<InsuranceCompany> response = _insuranceCompanyFactory.CreateMultipleFrom(insuranceCompanyDto);
            return response;
        }
    }
}
