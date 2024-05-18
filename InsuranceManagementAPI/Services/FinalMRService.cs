using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;

namespace InsuranceManagementAPI.Services
{
    public class FinalMRService : IFinalMRService
    {
        private readonly IFinalMRRepository _finalMRRepository;
        private readonly IFinalMRFactory _finalMRFactory;

        public FinalMRService(IFinalMRRepository finalMRRepository, IFinalMRFactory finalMRFactory)
        {
            _finalMRRepository = finalMRRepository;
            _finalMRFactory = finalMRFactory;
        }
        public async Task<FinalMR> Create(FinalMR finalMR)
        {
            FinalMR? response = null;
            var finalMRDto = _finalMRFactory.CreateFrom(finalMR);

            try
            {
                var insertedId = _finalMRRepository.Add(finalMRDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                finalMRDto = await _finalMRRepository.GetFinalMRByID(insertedId);

                response = _finalMRFactory.CreateFrom(finalMRDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
        public async Task<FinalMR?> Update(FinalMR finalMR)
        {
            FinalMR? response = null;
            var finalMRDto = _finalMRFactory.CreateFrom(finalMR);

            try
            {
                var result = _finalMRRepository.Update(finalMRDto).Result;
                if (!result)
                {
                    return response;
                }

                finalMRDto = await _finalMRRepository.GetFinalMRByID(finalMRDto.FinalMRKey);

                response = _finalMRFactory.CreateFrom(finalMRDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
        public async Task<FinalMR> GetFinalMRByKey(long finalMRKey)
        {
            var finalMRDto = await _finalMRRepository.GetFinalMRByID(finalMRKey);

            return _finalMRFactory.CreateFrom(finalMRDto);
        }
        public async Task<FinalMR> GetFinalMRByCodeBranchYear(FinalMR finalMR)
        {
            FinalMRDto searObj = _finalMRFactory.CreateFrom(finalMR);
            var finalMRDto = await _finalMRRepository.GetFinalMRByCodeBranchYear(searObj);

            return _finalMRFactory.CreateFrom(finalMRDto);
        }
    }
}
