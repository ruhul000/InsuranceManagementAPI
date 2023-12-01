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
                companyDto.ComKey = insertedId;

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

        public async Task<IEnumerable<Company>> GetAll()
        {
            var companyDtos = await _companyRepository.GetAll();

            return _companyFactory.CreateMultipleFrom(companyDtos);
        }

        public async Task<Company> GetById(int CompanyId)
        {
            var companyDto = await _companyRepository.GetByID(CompanyId);

            return _companyFactory.CreateFrom(companyDto);
        }

        public Task<Company> Update(Company company)
        {
            Company? response = null;
            var companyDto = _companyFactory.CreateFrom(company);

            try
            {
                var result =  _companyRepository.Update(companyDto).Result;
                if (!result)
                {
                    return Task.FromResult<Company>(response);
                }

                

                response = _companyFactory.CreateFrom(companyDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Company>(response);
            }

            return Task.FromResult(response);
        }
    }
}
