using AspNetCore.Reporting;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Report;
using QRCoder;
using System.Data;
using System.Drawing;

namespace InsuranceManagementAPI.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IReportRepository _reportRepository;
        public ReportingService(
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration,
            IReportRepository reportRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
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
                "FinalMR" => "rptFinalMR.rdlc",
                "OMP" => "rptOMP.rdlc",
                "Motor" => "rptMotor.rdlc"
            };

            return name;
        }
        private string GetReportSubDirectory(string reportType)
        {
            var subDirectory = reportType switch
            {
                "BankList" => _configuration.GetValue<string>("ReportTemplatePath:Bank"),
                "FinalMR" => _configuration.GetValue<string>("ReportTemplatePath:FinalMR"),
                "OMP" => _configuration.GetValue<string>("ReportTemplatePath:OMP"),
                "Motor" => _configuration.GetValue<string>("ReportTemplatePath:Motor"),
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
        public ReportDocument ReportFinalMR(FinalMRReportParam param)
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

        public ReportDocument ReportOMP(FinalMRReportParam param)
        {
            ReportDocument report = new ReportDocument();

            try
            {
                var reportSettings = GetReportsSettings("OMP");

                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string qrCodeText = $"https://united-api.azurewebsites.net/api/v1/Reports/OMPReport/{param.FinalMRKey}"; // Change this to the appropriate data for your QR code
                Image qrCodeImage = GenerateQRCodeImage(qrCodeText);
                string base64QRCode = ImageToBase64(qrCodeImage);

                parameters.Add("QRCode", base64QRCode);

                DataSet bankReportDS = _reportRepository.GetFinalMRReportDataSet(param).Result;

                LocalReport localReport = new LocalReport(reportSettings.TemplatePath);
                localReport.AddDataSource("dsFinalMR", bankReportDS.Tables["dtFinalMR"]);
                localReport.AddDataSource("dsBranchInfo", bankReportDS.Tables["dtBranchInfo"]);
                localReport.AddDataSource("dsBankBranch", bankReportDS.Tables["dtBankBranch"]);
                localReport.AddDataSource("dsBanks", bankReportDS.Tables["dtBank"]);
                localReport.AddDataSource("dsClient", bankReportDS.Tables["dtClient"]);

                var result = localReport.Execute(RenderType.Pdf, reportSettings.EXTENSION, parameters, reportSettings.MIMETYPE);

                Console.WriteLine("FileName: " + reportSettings.ReportFileName + " | DownloadPath: " + reportSettings.DownloadPath + " | ReportTemplatePath: " + reportSettings.TemplatePath);

                if (SaveReport(reportSettings, result))
                {
                    report.FileName = reportSettings.ReportFileName;
                    report.FilePath = reportSettings.DownloadPath;
                    report.FileStream = result.MainStream;
                }

                report.FileStream = result.MainStream;
            }
            catch (Exception ex)
            { }

            return report;
        }

        public ReportDocument ReportMotor(FinalMRReportParam param)
        {
            ReportDocument report = new ReportDocument();

            try
            {
                var reportSettings = GetReportsSettings("Motor");

                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string qrCodeText = $"https://localhost:7141/api/v1/Reports/MotorReport/{param.FinalMRKey}"; // Change this to the appropriate data for your QR code
                Image qrCodeImage = GenerateQRCodeImage(qrCodeText);
                string base64QRCode = ImageToBase64(qrCodeImage);

                parameters.Add("QRCode", base64QRCode);

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
            catch (Exception ex)
            { }

            return report;
        }

        private Image GenerateQRCodeImage(string qrCodeText)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            return code.GetGraphic(3);
        }

        // Convert image to base64 string
        private string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
