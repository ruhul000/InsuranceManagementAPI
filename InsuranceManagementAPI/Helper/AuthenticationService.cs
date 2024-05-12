using InsuranceManagementAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InsuranceManagementAPI.Helper
{
    public class AuthenticationService : IAuthenticationService
    {
        private const int ITERATIONS = 2048;

        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateSalt()
        {
            var hmac = new HMACSHA512();

            return Convert.ToBase64String(hmac.Key);
        }
        public string EncryptPassword(string password, string salt)
        {
            string hash = null;
            try
            {
                var saltBytes = Convert.FromBase64String(salt);

                using (var rfcbytes = new Rfc2898DeriveBytes(password, saltBytes, ITERATIONS))
                {
                    hash = Convert.ToBase64String(rfcbytes.GetBytes(256));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return hash;
        }
        public string GenerateJWT(User user)
        {
            var jwtSettings = _configuration.GetSection("JWTSettings").Get<JWTSettings>();

            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.Sub, jwtSettings.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("FullName", user.FullName),
                new Claim("UserName", user.UserName),
                new Claim("Password", user.Password),
                new Claim("Salt", user.Salt),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(               
                jwtSettings.Issuer, 
                jwtSettings.Audience, 
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken(string username)
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public bool IsValidApiKey(string? apiKey)
        {
            if(string.IsNullOrEmpty(apiKey)) return false;

            var apiKeySettings = _configuration.GetSection("APIKeySettings").Get<APIKeySettings>();

            if(apiKeySettings == null || apiKeySettings.ApiKey != apiKey) return false;

            return true;
        }
    }
}
