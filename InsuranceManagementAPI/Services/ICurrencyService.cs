using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAll();
        Task<Currency> GetById(int CurrencyKey);
        Task<Currency> Create(Currency currency);
        Task<Currency> Update(Currency currency);
    }
}
