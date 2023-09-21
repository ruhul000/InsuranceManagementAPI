using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBranchRepository
    {
        Task<IEnumerable<BranchDto>> GetAll();
        Task<IEnumerable<BranchDto>> GetAllByCompanyID(int ComKey);        
        Task<BranchDto> GetByID(int BranchKey);
        Task<Int32> Add(BranchDto branchDto);
        Task<bool> Update(BranchDto branchDto);
        Task<bool> Remove(int BranchKey);

    }
}
