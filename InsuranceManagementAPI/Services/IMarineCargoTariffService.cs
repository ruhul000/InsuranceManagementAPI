using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IMarineCargoTariffService
    {
        Task<IEnumerable<MarineCargoTariff>> GetTariffCategories();
        Task<IEnumerable<MarineCargoTariff>> GetItemNames(String TariffCategory, String RiskType);
        Task<IEnumerable<MarineCargoTariff>> GetTypeA(String TariffCategory, String RiskType, String ItemName);
        Task<IEnumerable<MarineCargoTariff>> GetTypeB(String TariffCategory, String RiskType, String ItemName, String TypeA);
        Task<IEnumerable<MarineCargoTariff>> GetTypeC(String TariffCategory, String RiskType, String ItemName, String TypeA, String TypeB);
        Task<IEnumerable<MarineCargoTariff>> GetRate(String TariffCategory, String RiskType, String ItemName, String TypeA, String TypeB,string TypeC);

    }
}
