using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IFinalMRService
    {
        Task<FinalMR> Create(FinalMR finalMR);

        Task<FinalMR?> Update(FinalMR finalMR);

        Task<FinalMR> GetFinalMRByKey(long finalMRKey);
        Task<FinalMR> GetFinalMRByCodeBranchYear(FinalMR finalMR);
    }
}
