using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IFinalMRFactory
    {
        IEnumerable<FinalMRDto> CreateMultipleFrom(IEnumerable<FinalMR> finalMR);
        IEnumerable<FinalMR> CreateMultipleFrom(IEnumerable<FinalMRDto> finalMRDto);

        FinalMR CreateFrom(FinalMRDto finalMRDto);
        FinalMRDto CreateFrom(FinalMR finalMR);
    }
}
