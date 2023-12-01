namespace InsuranceManagementAPI.Models
{
    public class Company
    {
        public int ComKey { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; } 
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? IssuingPlaceHO { get; set; }
        public string? Web { get; set; }
        public String? Logo { get; set; }= null;
        public String? LHead { get; set; } = null;
        public Boolean BackupType { get; set; }

    }
}
