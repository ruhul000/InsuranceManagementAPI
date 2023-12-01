using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class DesignationService: IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly IDesignationFactory _designationFactory;

        public DesignationService(IDesignationRepository designationRepository, IDesignationFactory designationFactory)
        {
            _designationRepository = designationRepository;
            _designationFactory = designationFactory;
        }
        public async Task<Designation> Create(Designation designation)
        {
            Designation? response = null;
            var designationDto = _designationFactory.CreateFrom(designation);

            try
            {
                var insertedId = _designationRepository.Add(designationDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }


                //designationDto.DepKey = insertedId;

                response = _designationFactory.CreateFrom(designationDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int DepId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Designation>> GetAll()
        {
            var designationDtos = await _designationRepository.GetAll();

            return _designationFactory.CreateMultipleFrom(designationDtos);
        }

        public async Task<Designation> GetById(int DepId)
        {
            var designationDto = await _designationRepository.GetByID(DepId);

            return _designationFactory.CreateFrom(designationDto);
        }

        public Task<Designation> Update(Designation designation)
        {
            Designation? response = null;
            var designationDto = _designationFactory.CreateFrom(designation);

            try
            {
                var result = _designationRepository.Update(designationDto).Result;
                if (!result)
                {
                    return Task.FromResult<Designation>(response);
                }



                response = _designationFactory.CreateFrom(designationDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Designation>(response);
            }

            return Task.FromResult(response);

        }
    }
}
