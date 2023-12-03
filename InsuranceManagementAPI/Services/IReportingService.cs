using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;

namespace InsuranceManagementAPI.Services
{
    public interface IReportingService
    {
        ReportDocument GetBankList(BankReportParam param);
    }
}
