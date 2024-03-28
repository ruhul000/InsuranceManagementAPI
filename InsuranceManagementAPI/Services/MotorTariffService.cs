using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

namespace InsuranceManagementAPI.Services
{
    public class MotorTariffService : IMotorTariffService
    {
        private readonly IMotorTariffRepository _motorTariffRepository;
        private readonly IMotorTariffFactory _motorTariffFactory;

        public MotorTariffService(IMotorTariffRepository motorTariffRepository, IMotorTariffFactory motorTariffFactory)
        {
            _motorTariffRepository = motorTariffRepository;
            _motorTariffFactory = motorTariffFactory;
        }

        public async Task<IEnumerable<MotorTariff>> GetAll()
        {
            var motorTariff = await _motorTariffRepository.GetAll();

            var tmp = _motorTariffFactory.CreateMultipleFrom(motorTariff);
            return tmp;
        }
    }
}
