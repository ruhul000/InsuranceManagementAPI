using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IMotorTariffService
    {
        Task<IEnumerable<MotorTariff>> GetAll();
    }
}
