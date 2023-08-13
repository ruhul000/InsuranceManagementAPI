using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IUserService
    {
        Task<UserResponse> Registration(UserRequest userRequest);
        Task<AuthInformation> UserLogin(UserLoginRequest loginRequest);
        Task<AuthInformation> RefreshToken(AuthInformation authInfo);
    }
}
