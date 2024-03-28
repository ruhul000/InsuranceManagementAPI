using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IBankPaymentService
    {
        Task<bool> Update(BankPayment bankPayment);
    }
}
