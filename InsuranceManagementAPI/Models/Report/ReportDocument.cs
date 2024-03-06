namespace InsuranceManagementAPI.Models.Report
{
    public class ReportDocument
    {
        public string? FileName { get; set; }
        public string FilePath { get; set; }
        public byte[]? FileStream { get; set; }
    }
}
