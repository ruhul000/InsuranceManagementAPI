using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class MotorTariffFactory: IMotorTariffFactory
    {
        IMappingFactory<MotorTariff> _motorTariffFactory;
        IMappingFactory<MotorTariffDto> _motorTariffDtoFactory;

        public MotorTariffFactory(IMappingFactory<MotorTariff> motorTariffFactory, IMappingFactory<MotorTariffDto> motorTariffDtoFactory)
        {
            _motorTariffFactory = motorTariffFactory;
            _motorTariffDtoFactory = motorTariffDtoFactory;
        }

        public MotorTariff CreateFrom(MotorTariffDto motorTariffDto)
        {
            MotorTariff response = _motorTariffFactory.CreateFrom(motorTariffDto);
            return response;
        }

        public MotorTariffDto CreateFrom(MotorTariff motorTariff)
        {
            MotorTariffDto response = _motorTariffDtoFactory.CreateFrom(motorTariff);
            return response;
        }

        public IEnumerable<MotorTariffDto> CreateMultipleFrom(IEnumerable<MotorTariff> motorTariff)
        {
            IEnumerable<MotorTariffDto> response = _motorTariffDtoFactory.CreateMultipleFrom(motorTariff);
            return response;
        }

        public IEnumerable<MotorTariff> CreateMultipleFrom(IEnumerable<MotorTariffDto> motorTariffDto)
        {
            IEnumerable<MotorTariff> response = _motorTariffFactory.CreateMultipleFrom(motorTariffDto);
            return response;
        }
    }
}
