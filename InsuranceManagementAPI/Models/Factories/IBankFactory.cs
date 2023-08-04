using InsuranceManagementAPI.Data;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IBankFactory
    {
        IEnumerable<BankDto> CreateMultipleFrom(IEnumerable<Bank> Bank);
        IEnumerable<Bank> CreateMultipleFrom(IEnumerable<BankDto> BankDtos);
    }
}
