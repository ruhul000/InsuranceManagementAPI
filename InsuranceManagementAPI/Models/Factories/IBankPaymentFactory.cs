using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IBankPaymentFactory
    {
        IEnumerable<BankPaymentDto> CreateMultipleFrom(IEnumerable<BankPayment> bankPayment);
        IEnumerable<BankPayment> CreateMultipleFrom(IEnumerable<BankPaymentDto> bankPaymentDto);

        BankPayment CreateFrom(BankPaymentDto bankPaymentDto);
        BankPaymentDto CreateFrom(BankPayment bankPayment);
    }
}
