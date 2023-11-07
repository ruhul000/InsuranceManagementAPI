using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class MarineCargoTariffFactory:IMarineCargoTariffFactory
    {
        IMappingFactory<MarineCargoTariff> _marineCargoTariffFactory;
        IMappingFactory<MarineCargoTariffDto> _marineCargoTariffDtoFactory;

        public MarineCargoTariffFactory(IMappingFactory<MarineCargoTariff> marineCargoTariffFactory, IMappingFactory<MarineCargoTariffDto> marineCargoTariffDtoFactory)
        {
            _marineCargoTariffFactory = marineCargoTariffFactory;
            _marineCargoTariffDtoFactory = marineCargoTariffDtoFactory;
        }

        public MarineCargoTariff CreateFrom(MarineCargoTariffDto marineCargoTariffDto)
        {
            MarineCargoTariff response = _marineCargoTariffFactory.CreateFrom(marineCargoTariffDto);
            return response;
        }

        public MarineCargoTariffDto CreateFrom(MarineCargoTariff marineCargoTariff)
        {
            MarineCargoTariffDto response = _marineCargoTariffDtoFactory.CreateFrom(marineCargoTariff);
            return response;
        }

        public IEnumerable<MarineCargoTariffDto> CreateMultipleFrom(IEnumerable<MarineCargoTariff> marineCargoTariff)
        {
            IEnumerable<MarineCargoTariffDto> response = _marineCargoTariffDtoFactory.CreateMultipleFrom(marineCargoTariff);
            return response;
        }

        public IEnumerable<MarineCargoTariff> CreateMultipleFrom(IEnumerable<MarineCargoTariffDto> marineCargoTariffDto)
        {
            IEnumerable<MarineCargoTariff> response = _marineCargoTariffFactory.CreateMultipleFrom(marineCargoTariffDto);
            return response;
        }
    }
}
