using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class BankPaymentFactory : IBankPaymentFactory
    {
        IMappingFactory<BankPayment> _bankPaymentFactory;
        IMappingFactory<BankPaymentDto> _bankPaymentDtoFactory;
        public BankPaymentFactory(IMappingFactory<BankPayment> bankPaymentFactory, IMappingFactory<BankPaymentDto> bankPaymentDtoFactory)
        {
            _bankPaymentFactory = bankPaymentFactory;
            _bankPaymentDtoFactory = bankPaymentDtoFactory;
        }

        BankPayment IBankPaymentFactory.CreateFrom(BankPaymentDto bankPaymentDto)
        {
            return _bankPaymentFactory.CreateFrom(bankPaymentDto);
        }

        BankPaymentDto IBankPaymentFactory.CreateFrom(BankPayment bankPayment)
        {
            return _bankPaymentDtoFactory.CreateFrom(bankPayment);
        }

        IEnumerable<BankPaymentDto> IBankPaymentFactory.CreateMultipleFrom(IEnumerable<BankPayment> bankPayment)
        {
            IEnumerable<BankPaymentDto> bankPayments = _bankPaymentDtoFactory.CreateMultipleFrom(bankPayment);
            return bankPayments;
        }

        IEnumerable<BankPayment> IBankPaymentFactory.CreateMultipleFrom(IEnumerable<BankPaymentDto> bankPaymentDto)
        {
            IEnumerable<BankPayment> bankPayments = _bankPaymentFactory.CreateMultipleFrom(bankPaymentDto);
            return bankPayments;
        }
    }
}
