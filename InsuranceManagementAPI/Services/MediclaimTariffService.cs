using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

namespace InsuranceManagementAPI.Services
{
    public class MediclaimTariffService : IMediclaimTariffService
    {
        private readonly IMediclaimTariffRepository _mediclaimTariffRepository;
        private readonly IMediclaimTariffFactory _mediclaimTariffFactory;

        public MediclaimTariffService(IMediclaimTariffRepository mediclaimTariffRepository, IMediclaimTariffFactory mediclaimTariffFactory)
        {
            _mediclaimTariffRepository = mediclaimTariffRepository;
            _mediclaimTariffFactory = mediclaimTariffFactory;
        }

        public async Task<IEnumerable<MediclaimTariff>> GetTravelRate(int Days, int Age, int Tariff_Type, int Travel_Type)
        {
            var mediclaimTariffDtos = await _mediclaimTariffRepository.GetTravelRate(Days, Age, Tariff_Type, Travel_Type);

            return _mediclaimTariffFactory.CreateMultipleFrom(mediclaimTariffDtos);
        }

        
    }
}
