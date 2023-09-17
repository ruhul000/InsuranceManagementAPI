using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        IMappingFactory<Company> _companyFactory;
        IMappingFactory<CompanyDto> _companyDtoFactory;

        public CompanyFactory(IMappingFactory<Company> companyFactory, IMappingFactory<CompanyDto> companyDtoFactory)
        {
            _companyFactory = companyFactory;
            _companyDtoFactory = companyDtoFactory;
        }

        public Company CreateFrom(CompanyDto companyDto)
        {
            Company response = _companyFactory.CreateFrom(companyDto);
            return response;
        }

        public CompanyDto CreateFrom(Company company)
        {
            CompanyDto response = _companyDtoFactory.CreateFrom(company);
            return response;
        }

        public IEnumerable<CompanyDto> CreateMultipleFrom(IEnumerable<Company> company)
        {
            IEnumerable<CompanyDto> response = _companyDtoFactory.CreateMultipleFrom(company);
            return response;
        }

        public IEnumerable<Company> CreateMultipleFrom(IEnumerable<CompanyDto> companyDto)
        {
            IEnumerable<Company> response = _companyFactory.CreateMultipleFrom(companyDto);
            return response;
        }
    }
}
