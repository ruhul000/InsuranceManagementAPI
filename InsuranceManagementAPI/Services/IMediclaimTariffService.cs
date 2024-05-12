using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IMediclaimTariffService
    {
        Task<IEnumerable<MediclaimTariff>> GetTravelRate(int Days, int Age, int Tariff_Type, int Travel_Type);
    }
}