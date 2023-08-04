using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;

namespace InsuranceManagementAPI.Helper
{
    public class EncryptionService : IEncryptionService
    {
        private const int ITERATIONS = 2048;
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


    }
}
