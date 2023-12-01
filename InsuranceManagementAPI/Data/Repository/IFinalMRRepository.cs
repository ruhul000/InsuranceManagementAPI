using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IFinalMRRepository
    {
        Task<long> Add(FinalMRDto finalMRDto);
        Task<FinalMRDto> GetFinalMRByID(long FinalMRKey);
    }
}
