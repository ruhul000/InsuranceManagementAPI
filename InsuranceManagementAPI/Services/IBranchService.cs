using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAll();
        Task<IEnumerable<Branch>> GetAllByCompanyID(int ComKey);        
        Task<Branch> GetById(int BranchKey);
        Task<Branch> Create(Branch branch);
        Task<Branch> Update(Branch branch);
        Task<bool> Delete(int BranchKey);
    }
}
