using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenDto?> Get(String username, string refreshToken);
        Task<bool> Save(RefreshTokenDto refreshTokenDto);
    }
}
