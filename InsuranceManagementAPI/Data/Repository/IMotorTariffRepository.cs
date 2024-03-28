using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IMotorTariffRepository
    {
        Task<IEnumerable<MotorTariffDto>> GetAll();
    }
}
