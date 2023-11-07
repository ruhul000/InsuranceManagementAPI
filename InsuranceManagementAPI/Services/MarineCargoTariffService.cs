using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

namespace InsuranceManagementAPI.Services
{
    public class MarineCargoTariffService : IMarineCargoTariffService
    {
        private readonly IMarineCargoTariffRepository _marineCargoTariffRepository;
        private readonly IMarineCargoTariffFactory _marineCargoTariffFactory;

        public MarineCargoTariffService(IMarineCargoTariffRepository marineCargoTariffRepository, IMarineCargoTariffFactory marineCargoTariffFactory)
        {
            _marineCargoTariffRepository = marineCargoTariffRepository;
            _marineCargoTariffFactory = marineCargoTariffFactory;
        }
        public async Task<IEnumerable<MarineCargoTariff>> GetTariffCategories()
        {
            var marineCargoTariffDtos = await _marineCargoTariffRepository.GetTariffCategories();

            return _marineCargoTariffFactory.CreateMultipleFrom(marineCargoTariffDtos);
        }
        public async Task<IEnumerable<MarineCargoTariff>> GetItemNames(string TariffCategory, string RiskType)
        {
            var marineCargoTariffDtos = await _marineCargoTariffRepository.GetItemNames(TariffCategory,RiskType);

            return _marineCargoTariffFactory.CreateMultipleFrom(marineCargoTariffDtos);
        }       

        public Task<IEnumerable<MarineCargoTariff>> GetTypeA(string TariffCategory, string RiskType, string ItemName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarineCargoTariff>> GetTypeB(string TariffCategory, string RiskType, string ItemName, string TypeA)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarineCargoTariff>> GetTypeC(string TariffCategory, string RiskType, string ItemName, string TypeA, string TypeB)
        {
            throw new NotImplementedException();
        }
    }
}
