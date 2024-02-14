using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IMediclaimTariffRepository
    {
        Task<IEnumerable<MediclaimTariffDto>> GetTravelRate(int  Days, int Age, int Tariff_Type, int Travel_Type);
    }
}
