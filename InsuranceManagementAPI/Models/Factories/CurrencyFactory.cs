using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class CurrencyFactory: ICurrencyFactory
    {
        IMappingFactory<Currency> _currencyFactory;
        IMappingFactory<CurrencyDto> _currencyDtoFactory;

        public CurrencyFactory(IMappingFactory<Currency> currencyFactory, IMappingFactory<CurrencyDto> currencyDtoFactory)
        {
            _currencyFactory = currencyFactory;
            _currencyDtoFactory = currencyDtoFactory;
        }

        public Currency CreateFrom(CurrencyDto currencyDto)
        {
            Currency response = _currencyFactory.CreateFrom(currencyDto);
            return response;
        }

        public CurrencyDto CreateFrom(Currency currency)
        {
            CurrencyDto response = _currencyDtoFactory.CreateFrom(currency);
            return response;
        }

        public IEnumerable<CurrencyDto> CreateMultipleFrom(IEnumerable<Currency> currency)
        {
            IEnumerable<CurrencyDto> response = _currencyDtoFactory.CreateMultipleFrom(currency);
            return response;
        }

        public IEnumerable<Currency> CreateMultipleFrom(IEnumerable<CurrencyDto> currencyDto)
        {
            IEnumerable<Currency> response = _currencyFactory.CreateMultipleFrom(currencyDto);
            return response;
        }
    }
}
