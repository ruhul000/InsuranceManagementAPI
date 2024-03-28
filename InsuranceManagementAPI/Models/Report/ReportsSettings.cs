namespace InsuranceManagementAPI.Models.Report
{
    public class ReportsSettings
    {
        public string TemplatePath { get; set; }
        public string DownloadPath { get; set; }
        public string ReportFileName { get; set; }

        public int EXTENSION { get; set; }
        public string MIMETYPE { get; set; }
    }
}
