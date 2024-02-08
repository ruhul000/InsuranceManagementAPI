using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;

namespace InsuranceManagementAPI.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBankService _bankService;
        private readonly IReportRepository _reportRepository;

        public ReportingService(
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration,
            IBankService bankService,
            IReportRepository reportRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _bankService = bankService;
            _reportRepository = reportRepository;
        }
        private ReportsSettings GetReportsSettings(string reportType)
        {
            ReportsSettings reportSettings = new ReportsSettings();
            string REPORT_TEMPLATE_PATH = $"{_webHostEnvironment.WebRootPath}\\ReportsTemplate\\";
            string REPORT_DOWNLOAD_PATH = $"{_webHostEnvironment.WebRootPath}\\ReportsDownload\\";

            string ReportTemplateName = GetReportTemplateName(reportType);
            var subDirectory = GetReportSubDirectory(reportType);

            reportSettings.EXTENSION = 1;
            reportSettings.MIMETYPE = "";
            reportSettings.ReportFileName = reportType + DateTime.Now.ToFileTime() + ".pdf";
            reportSettings.TemplatePath = REPORT_TEMPLATE_PATH + subDirectory + ReportTemplateName;
            reportSettings.DownloadPath = REPORT_DOWNLOAD_PATH + reportSettings.ReportFileName;

            return reportSettings;
        }
        private string GetReportTemplateName(string reportype)
        {
            var name = reportype switch
            {
                "BankList" => "rptBanks.rdlc",
                "FinalMR" => "rptFinalMR.rdlc"
            };

            return name;
        }
        private string GetReportSubDirectory(string reportType)
        {
            var subDirectory = reportType switch
            {
                "BankList" => _configuration.GetValue<string>("ReportTemplatePath:Bank"),
                "FinalMR" => _configuration.GetValue<string>("ReportTemplatePath:FinalMR"),
            };

            return subDirectory;
        }    
        private bool SaveReport(ReportsSettings reportSettings, ReportResult? result) 
        {
            try
            {
                using (var fileStream = new FileStream(reportSettings.DownloadPath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(result.MainStream, 0, result.MainStream.Length);
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public ReportDocument GenerateBankReport(BankReportParam param)
        {
            ReportDocument report = new ReportDocument();

            var reportSettings = GetReportsSettings("BankList");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rptTitle", param.Title);

            DataSet bankReportDS = _reportRepository.GetBankReportDataSet(1).Result;

            LocalReport localReport = new LocalReport(reportSettings.TemplatePath);
            localReport.AddDataSource("dsBank", bankReportDS.Tables[0]);
            //localReport.AddDataSource("dsBranch", bankReportDS.Tables[1]);

            var result = localReport.Execute(RenderType.Pdf, reportSettings.EXTENSION, parameters, reportSettings.MIMETYPE);

            if(SaveReport(reportSettings, result))
            {
                report.FileName = reportSettings.ReportFileName;
                report.FilePath = reportSettings.DownloadPath;
                report.FileStream = result.MainStream;
            }

            return report;
        }
        public ReportDocument ReportFinalMR(FinalMRReporParam param)
        {
            ReportDocument report = new ReportDocument();

            try
            {
                var reportSettings = GetReportsSettings("FinalMR");

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                //parameters.Add("rptTitle", param.Title);

                DataSet bankReportDS = _reportRepository.GetFinalMRReportDataSet(param).Result;

                LocalReport localReport = new LocalReport(reportSettings.TemplatePath);
                localReport.AddDataSource("dsFinalMR", bankReportDS.Tables["dtFinalMR"]);
                localReport.AddDataSource("dsBranchInfo", bankReportDS.Tables["dtBranchInfo"]);
                localReport.AddDataSource("dsBankBranch", bankReportDS.Tables["dtBankBranch"]);
                localReport.AddDataSource("dsBanks", bankReportDS.Tables["dtBank"]);
                localReport.AddDataSource("dsClient", bankReportDS.Tables["dtClient"]);

                var result = localReport.Execute(RenderType.Pdf, reportSettings.EXTENSION, parameters, reportSettings.MIMETYPE);

                if (SaveReport(reportSettings, result))
                {
                    report.FileName = reportSettings.ReportFileName;
                    report.FilePath = reportSettings.DownloadPath;
                    report.FileStream = result.MainStream;
                }

                report.FileStream = result.MainStream;
            }
            catch(Exception ex)
            {}

            return report;
        }
    }
}
