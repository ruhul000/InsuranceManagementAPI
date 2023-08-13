using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using System.Threading.Tasks;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByUserName(string username);
        Task<bool> Add(UserDto user);
    }
}
