using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface ICurrencyFactory
    {
        IEnumerable<CurrencyDto> CreateMultipleFrom(IEnumerable<Currency> currency);
        IEnumerable<Currency> CreateMultipleFrom(IEnumerable<CurrencyDto> currencyDtos);

        Currency CreateFrom(CurrencyDto currencyDto);
        CurrencyDto CreateFrom(Currency currency);
    }
}
