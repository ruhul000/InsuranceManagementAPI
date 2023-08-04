namespace InsuranceManagementAPI.Helper
{
    public interface IEncryptionService
    {
        string GenerateSalt();
        string EncryptPassword(string password, string salt);
    }
}
