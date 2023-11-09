using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IMarineCargoTariffRepository
    {
        Task<IEnumerable<MarineCargoTariffDto>> GetTariffCategories();
        Task<IEnumerable<MarineCargoTariffDto>> GetItemNames(String TariffCategory, String RiskType);
        Task<IEnumerable<MarineCargoTariffDto>> GetTypeA(String TariffCategory, String RiskType, String ItemName);
        Task<IEnumerable<MarineCargoTariffDto>> GetTypeB(String TariffCategory, String RiskType, String ItemName, String TypeA);
        Task<IEnumerable<MarineCargoTariffDto>> GetTypeC(String TariffCategory, String RiskType, String ItemName, String TypeA, String TypeB);
        Task<IEnumerable<MarineCargoTariffDto>> GetRate(String TariffCategory, String RiskType, String ItemName, String TypeA, String TypeB,String TypeC);

    }
}
