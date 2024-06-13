using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Helper
{
    public interface IAuthenticationService
    {
        string GenerateSalt();
        string EncryptPassword(string password, string salt);
        string GenerateJWT(User user);
        string GenerateRefreshToken(string username);
        bool IsValidApiKey(string? apiKey);
    }
}
