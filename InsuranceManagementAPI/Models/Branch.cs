using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementAPI.Models
{
    public class Branch
    {
        public int ComKey { get; set; }
        public int BranchKey { get; set; }
        public string? BranchID { get; set; }
        public int? BranchOrderKey { get; set; }
        public DateTime? Branch_Open_Date { get; set;}
        [Required]
        public String? BranchName { get; set; }
        public string? ShortName { get; set;}
        public int? ZoneKey { get; set;}
        public String? Address { get; set; }
        public String? Branch_Address_2 { get; set; }
        public String? Branch_Address_3 { get; set; }
        public String? Phone { get; set; }
        public String? Mobile { get; set; }
        public String? Fax { get; set; }
        public String? EMail { get; set; } = null;
        public int? EmpKeyIncharge { get; set; }
        public String? IssuingPlace { get; set; } 
        public String? IssuingPlace_2 { get;set; }
        public String? IssuingPlace_3 { get;set; }
        public Boolean? Computerized { get; set; }
        public String? Seal { get;set; }
        public String? Signatore_Name_A { get; set;}
        public String? Signatore_A { get; set; }
        public String? Signatore_Name_B { get; set; }
        public String? Signatore_B { get; set; }
        public String? Signatore_Name_C { get; set; }
        public String? Signatore_C { get; set; }
        public Boolean Status { get; set; }
        public Boolean BackupType { get; set; }

    }
}
