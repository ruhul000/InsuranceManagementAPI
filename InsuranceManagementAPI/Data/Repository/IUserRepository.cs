using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using System.Threading.Tasks;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<bool> Add(UserDto user);
    }
}
