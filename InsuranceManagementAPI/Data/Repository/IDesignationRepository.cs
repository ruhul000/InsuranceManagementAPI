using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<DesignationDto>> GetAll();
        Task<DesignationDto> GetByID(int degId);
        Task<int> Add(DesignationDto designationDto);
        Task<bool> Update(DesignationDto designationDto);
    }
}
