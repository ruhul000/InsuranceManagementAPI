using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;

namespace InsuranceManagementAPI.Services
{
    public class ReportingService : IReportingService
    {
        private readonly int EXTENSION = 1;
        private readonly string MIMETYPE = "";
        private readonly string REPORT_TEMPLATE_PATH;
        private readonly string REPORT_DOWNLOAD_PATH;

        private readonly IConfiguration _configuration;
        private readonly IBankService _bankService;

        public ReportingService(
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration,
            IBankService bankService)
        {
            REPORT_TEMPLATE_PATH = $"{webHostEnvironment.WebRootPath}\\ReportsTemplate\\";
            REPORT_DOWNLOAD_PATH = $"{webHostEnvironment.WebRootPath}\\ReportsDownload\\";
            
            _configuration = configuration;
            _bankService = bankService;
        }
        public ReportDocument GetBankList(BankReportParam param)
        {
            ReportDocument report = new ReportDocument();

            string ReportTemplateName = "rptBanks.rdlc";
            string ReportFileName = "ReportBankList-" + DateTime.Now.ToFileTime() + ".pdf";

            var subDirectory = _configuration.GetValue<string>("ReportTemplatePath:Bank");

            var templatePath = REPORT_TEMPLATE_PATH+ subDirectory + ReportTemplateName;
            var downloadPath = REPORT_DOWNLOAD_PATH + ReportFileName;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rptTitle", param.Title);

            var data = _bankService.GetAllBanks().Result.ToList();

            LocalReport localReport = new LocalReport(templatePath);
            localReport.AddDataSource("dsBanks", data);

            var res = localReport.Execute(RenderType.Pdf, EXTENSION, parameters, MIMETYPE);

            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(res.MainStream, 0, res.MainStream.Length);
            }

            report.FileName = ReportFileName;
            report.FilePath = downloadPath;
            report.FileStream = res.MainStream;

            return report;
        }
    }
}
