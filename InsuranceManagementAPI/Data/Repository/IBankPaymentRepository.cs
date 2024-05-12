using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IBankPaymentRepository
    {
        Task<bool> Update(BankPaymentDto bankPaymentDto);
    }
}
