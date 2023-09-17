using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

namespace InsuranceManagementAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyFactory _companyFactory;
        public CompanyService(ICompanyRepository companyRepository, ICompanyFactory companyFactory)
        {
            _companyRepository = companyRepository;
            _companyFactory = companyFactory;
        }
        public async Task<Company> Create(Company company)
        {
            Company? response = null;
            var companyDto = _companyFactory.CreateFrom(company);

            try
            {
                var insertedId = _companyRepository.Add(companyDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                //bankBranchDto = await _bankBranchRepository.GetBankBranchById(bankBranchDto.BranchId);
                companyDto.CompanyId = insertedId;

                response = _companyFactory.CreateFrom(companyDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
