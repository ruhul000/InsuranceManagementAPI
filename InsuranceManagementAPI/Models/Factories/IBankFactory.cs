using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IBankFactory
    {
        IEnumerable<BankDto> CreateMultipleFrom(IEnumerable<Bank> Bank);
        IEnumerable<Bank> CreateMultipleFrom(IEnumerable<BankDto> BankDtos);

        Bank CreateFrom(BankDto bankDto);
        BankDto CreateFrom(Bank bank);
    }
}
