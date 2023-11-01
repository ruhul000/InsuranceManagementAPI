using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class DesignationFactory : IDesignationFactory
    {
        IMappingFactory<Designation> _designationFactory;
        IMappingFactory<DesignationDto> _designationDtoFactory;

        public DesignationFactory(IMappingFactory<Designation> designationFactory, IMappingFactory<DesignationDto> designationDtoFactory)
        {
            _designationFactory = designationFactory;
            _designationDtoFactory = designationDtoFactory;
        }

        public Designation CreateFrom(DesignationDto designationDto)
        {
            Designation response = _designationFactory.CreateFrom(designationDto);
            return response;
        }

        public DesignationDto CreateFrom(Designation designation)
        {
            DesignationDto response = _designationDtoFactory.CreateFrom(designation);
            return response;
        }

        public IEnumerable<DesignationDto> CreateMultipleFrom(IEnumerable<Designation> designation)
        {
            IEnumerable<DesignationDto> response = _designationDtoFactory.CreateMultipleFrom(designation);
            return response;
        }

        public IEnumerable<Designation> CreateMultipleFrom(IEnumerable<DesignationDto> designationDto)
        {
            IEnumerable<Designation> response = _designationFactory.CreateMultipleFrom(designationDto);
            return response;
        }

       
    }
}
