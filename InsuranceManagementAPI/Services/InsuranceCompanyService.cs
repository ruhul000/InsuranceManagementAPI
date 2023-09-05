using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Services
{
    public class InsuranceCompanyService : IInsuranceCompanyService
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IInsuranceCompanyFactory _insuranceCompanyFactory;
        public InsuranceCompanyService(IInsuranceCompanyRepository insuranceCompanyRepository, IInsuranceCompanyFactory insuranceCompanyFactory)
        {
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _insuranceCompanyFactory = insuranceCompanyFactory;
        }
        public async Task<InsuranceCompany> Create(InsuranceCompany insuranceCompany)
        {
            InsuranceCompany? response = null;
            var insuranceCompanyDto = _insuranceCompanyFactory.CreateFrom(insuranceCompany);

            try
            {
                var insertedId = _insuranceCompanyRepository.Add(insuranceCompanyDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                //bankBranchDto = await _bankBranchRepository.GetBankBranchById(bankBranchDto.BranchId);
                insuranceCompanyDto.CompanyId = insertedId;

                response = _insuranceCompanyFactory.CreateFrom(insuranceCompanyDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public async Task<bool> Delete(int CompanyId)
        {
            var deleted = false;
            try
            {
                deleted = await _insuranceCompanyRepository.Remove(CompanyId);
                if (deleted)
                {
                    return deleted;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return deleted;
        }

        public async Task<IEnumerable<InsuranceCompany>> GetAll()
        {
            var insuranceCompanyDto = await _insuranceCompanyRepository.GetAll();

            return _insuranceCompanyFactory.CreateMultipleFrom(insuranceCompanyDto);
        }

        public async Task<InsuranceCompany> GetById(int CompanyId)
        {
            var insuranceCompanyDto = await _insuranceCompanyRepository.GetByID(CompanyId);

            return _insuranceCompanyFactory.CreateFrom(insuranceCompanyDto);
        }

        public async Task<InsuranceCompany> Update(InsuranceCompany insuranceCompany)
        {
            InsuranceCompany? response = null;
            var insuranceCompanyDto = _insuranceCompanyFactory.CreateFrom(insuranceCompany);

            try
            {
                var result = _insuranceCompanyRepository.Update(insuranceCompanyDto).Result;
                if (!result)
                {
                    return response;
                }

                insuranceCompanyDto = await _insuranceCompanyRepository.GetByID(insuranceCompanyDto.CompanyId);

                response = _insuranceCompanyFactory.CreateFrom(insuranceCompanyDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
    }
}
