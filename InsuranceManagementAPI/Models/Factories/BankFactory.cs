using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class BankFactory : IBankFactory
    {
        IMappingFactory<Bank> _bankFactory;
        IMappingFactory<BankDto> _bankDtoFactory;

        public BankFactory(IMappingFactory<Bank> bankFactory, IMappingFactory<BankDto> bankDtoFactory)
        {
            _bankFactory = bankFactory;
            _bankDtoFactory = bankDtoFactory;
        }
        public IEnumerable<BankDto> CreateMultipleFrom(IEnumerable<Bank> Bank)
        {
            IEnumerable<BankDto> response = _bankDtoFactory.CreateMultipleFrom(Bank);
            return response;
        }

        public IEnumerable<Bank> CreateMultipleFrom(IEnumerable<BankDto> BankDtos)
        {
            IEnumerable<Bank> response = _bankFactory.CreateMultipleFrom(BankDtos);
            return response;
        }
    }
}
