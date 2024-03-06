using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IFinalMRRepository
    {
        Task<long> Add(FinalMRDto finalMRDto);
        Task<bool> Update(FinalMRDto finalMRDto);
        Task<FinalMRDto> GetFinalMRByID(long FinalMRKey);
        Task<FinalMRDto> GetFinalMRByCodeBranchYear(FinalMRDto searchObj);
    }
}
