using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class InsuranceCompanyFactory: IInsuranceCompanyFactory
    {
        IMappingFactory<InsuranceCompany> _insuranceCompanyFactory;
        IMappingFactory<InsurancebranchDto> _insurancebranchDtoFactory;

        public InsuranceCompanyFactory(IMappingFactory<InsuranceCompany> insuranceCompanyFactory, IMappingFactory<InsurancebranchDto> insurancebranchDtoFactory)
        {
            _insuranceCompanyFactory = insuranceCompanyFactory;
            _insurancebranchDtoFactory = insurancebranchDtoFactory;
        }

        public InsuranceCompany CreateFrom(InsurancebranchDto insurancebranchDto)
        {
            return _insuranceCompanyFactory.CreateFrom(insurancebranchDto);
        }

        public InsurancebranchDto CreateFrom(InsuranceCompany insuranceCompany)
        {
            return _insurancebranchDtoFactory.CreateFrom(insuranceCompany);
        }

        public IEnumerable<InsurancebranchDto> CreateMultipleFrom(IEnumerable<InsuranceCompany> insuranceCompany)
        {
            IEnumerable<InsurancebranchDto> response = _insurancebranchDtoFactory.CreateMultipleFrom(insuranceCompany);
            return response;
        }

        public IEnumerable<InsuranceCompany> CreateMultipleFrom(IEnumerable<InsurancebranchDto> insurancebranchDto)
        {
            IEnumerable<InsuranceCompany> response = _insuranceCompanyFactory.CreateMultipleFrom(insurancebranchDto);
            return response;
        }
    }
}
