using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IInsuranceCompanyRepository
    {
        Task<IEnumerable<InsurancebranchDto>> GetAll();
        Task<InsurancebranchDto> GetByID(int id);
        Task<Int32> Add(InsurancebranchDto insurancebranchDto);
        Task<bool> Update(InsurancebranchDto insurancebranchDto);
        Task<bool> Remove(int companyId);
    }
}
