using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IMediclaimTariffFactory
    {
        IEnumerable<MediclaimTariffDto> CreateMultipleFrom(IEnumerable<MediclaimTariff> mediclaimTariff);
        IEnumerable<MediclaimTariff> CreateMultipleFrom(IEnumerable<MediclaimTariffDto> mediclaimTariffDto);

        MediclaimTariff CreateFrom(MediclaimTariffDto mediclaimTariffDto);
        MediclaimTariffDto CreateFrom(MediclaimTariff mediclaimTariff);
    }
}
