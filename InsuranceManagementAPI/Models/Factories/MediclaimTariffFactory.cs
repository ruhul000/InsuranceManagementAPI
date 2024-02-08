using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class MediclaimTariffFactory:IMediclaimTariffFactory
    {
        IMappingFactory<MediclaimTariff> _mediclaimTariffFactory;
        IMappingFactory<MediclaimTariffDto> _mediclaimTariffDtoFactory;

        public MediclaimTariffFactory(IMappingFactory<MediclaimTariff> mediclaimTariffFactory, IMappingFactory<MediclaimTariffDto> mediclaimTariffDtoFactory)
        {
            _mediclaimTariffFactory = mediclaimTariffFactory;
            _mediclaimTariffDtoFactory = mediclaimTariffDtoFactory;
        }

        public MediclaimTariff CreateFrom(MediclaimTariffDto mediclaimTariffDto)
        {
            MediclaimTariff response = _mediclaimTariffFactory.CreateFrom(mediclaimTariffDto);
            return response;
        }

        public MediclaimTariffDto CreateFrom(MediclaimTariff mediclaimTariff)
        {
            MediclaimTariffDto response = _mediclaimTariffDtoFactory.CreateFrom(mediclaimTariff);
            return response;
        }

        public IEnumerable<MediclaimTariffDto> CreateMultipleFrom(IEnumerable<MediclaimTariff> mediclaimTariff)
        {
            IEnumerable<MediclaimTariffDto> response = _mediclaimTariffDtoFactory.CreateMultipleFrom(mediclaimTariff);
            return response;
        }

        public IEnumerable<MediclaimTariff> CreateMultipleFrom(IEnumerable<MediclaimTariffDto> mediclaimTariffDto)
        {
            IEnumerable<MediclaimTariff> response = _mediclaimTariffFactory.CreateMultipleFrom(mediclaimTariffDto);
            return response;
        }
    }
}
