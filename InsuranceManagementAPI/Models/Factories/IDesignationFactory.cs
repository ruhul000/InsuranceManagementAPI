using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IDesignationFactory
    {
        IEnumerable<DesignationDto> CreateMultipleFrom(IEnumerable<Designation> designation);
        IEnumerable<Designation> CreateMultipleFrom(IEnumerable<DesignationDto> designationDto);

        Designation CreateFrom(DesignationDto designationDto);
        DesignationDto CreateFrom(Designation designation);
    }
}
