using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IMotorTariffFactory
    {
        IEnumerable<MotorTariffDto> CreateMultipleFrom(IEnumerable<MotorTariff> motorTariff);
        IEnumerable<MotorTariff> CreateMultipleFrom(IEnumerable<MotorTariffDto> motorTariffDto);

        MotorTariff CreateFrom(MotorTariffDto motorTariffDto);
        MotorTariffDto CreateFrom(MotorTariff motorTariff);
    }
}
