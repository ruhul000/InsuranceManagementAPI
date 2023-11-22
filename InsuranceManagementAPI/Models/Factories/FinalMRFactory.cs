using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class FinalMRFactory: IFinalMRFactory
    {
        IMappingFactory<FinalMR> _finalMRFactory;
        IMappingFactory<FinalMRDto> _finalMRDtoFactory;

        public FinalMRFactory(IMappingFactory<FinalMR> finalMRFactory, IMappingFactory<FinalMRDto> finalMRDtoFactory)
        {
            _finalMRFactory = finalMRFactory;
            _finalMRDtoFactory = finalMRDtoFactory;
        }

        public FinalMR CreateFrom(FinalMRDto finalMRDto)
        {
            FinalMR response = _finalMRFactory.CreateFrom(finalMRDto);
            return response;
        }

        public FinalMRDto CreateFrom(FinalMR finalMR)
        {
            FinalMRDto response = _finalMRDtoFactory.CreateFrom(finalMR);
            return response;
        }

        public IEnumerable<FinalMRDto> CreateMultipleFrom(IEnumerable<FinalMR> finalMR)
        {
            IEnumerable<FinalMRDto> response = _finalMRDtoFactory.CreateMultipleFrom(finalMR);
            return response;
        }

        public IEnumerable<FinalMR> CreateMultipleFrom(IEnumerable<FinalMRDto> finalMRDto)
        {
            IEnumerable<FinalMR> response = _finalMRFactory.CreateMultipleFrom(finalMRDto);
            return response;
        }
    }
}
