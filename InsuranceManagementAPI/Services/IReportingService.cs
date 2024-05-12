using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;

namespace InsuranceManagementAPI.Services
{
    public interface IReportingService
    {
        ReportDocument GenerateBankReport(BankReportParam param);
        ReportDocument ReportFinalMR(FinalMRReporParam param);
        ReportDocument ReportOMP(FinalMRReporParam param);
        ReportDocument ReportMotor(FinalMRReporParam param);
    }
}
