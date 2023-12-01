using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IMarineCargoTariffFactory
    {
        IEnumerable<MarineCargoTariffDto> CreateMultipleFrom(IEnumerable<MarineCargoTariff> marineCargoTariff);
        IEnumerable<MarineCargoTariff> CreateMultipleFrom(IEnumerable<MarineCargoTariffDto> marineCargoTariffDto);

        MarineCargoTariff CreateFrom(MarineCargoTariffDto marineCargoTariffDto);
        MarineCargoTariffDto CreateFrom(MarineCargoTariff marineCargoTariff);
    }
}
