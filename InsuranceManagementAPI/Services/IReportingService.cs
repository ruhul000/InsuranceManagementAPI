using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;

namespace InsuranceManagementAPI.Services
{
    public interface IReportingService
    {
        ReportDocument GenerateBankReport(BankReportParam param);
        ReportDocument ReportFinalMR(FinalMRReportParam param);
        ReportDocument ReportOMP(FinalMRReportParam param);
        ReportDocument ReportMotor(FinalMRReportParam param);
    }
}
