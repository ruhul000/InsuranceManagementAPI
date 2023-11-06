using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<CurrencyDto>> GetAll();
        Task<CurrencyDto> GetByID(int depId);
        Task<int> Add(CurrencyDto currencyDto);
        Task<bool> Update(CurrencyDto currencyDto);
    }
}
