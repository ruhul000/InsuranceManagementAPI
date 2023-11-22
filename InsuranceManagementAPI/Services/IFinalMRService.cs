using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IFinalMRService
    {
        Task<FinalMR> Create(FinalMR finalMR);
    }
}
