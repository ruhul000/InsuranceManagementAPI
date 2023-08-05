using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IUserService
    {
        Task<UserResponse> Registration(UserRequest userRequest);
        Task<AuthResponse> UserLogin(UserLoginRequest loginRequest);
    }
}
