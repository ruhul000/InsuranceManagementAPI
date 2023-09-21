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
            var branchDto = _companyFactory.CreateFrom(company);

            try
            {
                var insertedId = _companyRepository.Add(branchDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                //bankBranchDto = await _bankBranchRepository.GetBankBranchById(bankBranchDto.BranchId);
                branchDto.ComKey = insertedId;

                response = _companyFactory.CreateFrom(branchDto);
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
            var branchDtos = await _companyRepository.GetAll();

            return _companyFactory.CreateMultipleFrom(branchDtos);
        }

        public async Task<Company> GetById(int CompanyId)
        {
            var branchDto = await _companyRepository.GetByID(CompanyId);

            return _companyFactory.CreateFrom(branchDto);
        }

        public Task<Company> Update(Company company)
        {
            Company? response = null;
            var branchDto = _companyFactory.CreateFrom(company);

            try
            {
                var result =  _companyRepository.Update(branchDto).Result;
                if (!result)
                {
                    return Task.FromResult<Company>(response);
                }

                

                response = _companyFactory.CreateFrom(branchDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Company>(response);
            }

            return Task.FromResult(response);
        }
    }
}
