using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("tab_AgentInfo")]
    public class AgentDto
    {        
        [Key]
        public int AgentKey { get; set; }
        public int BranchKey { get; set; }
        public string? AgentID { get; set; }
        public string? AgentCode { get; set; }
        public string? Agent_Title { get; set; }
        public string? AgentName { get; set; }
        public string? Agent_Address { get; set; }
        public string? Agent_License_No { get; set; }
        public string? Agent_Bank_Name { get; set; }
        public String? Agent_Bank_Branch_Name { get; set; }
        public String? Agent_Bank_Account_No { get; set; }
        public int? Ref_EmpKey { get; set; }
        public DateTime? Validity_From { get; set; }
        public DateTime? Validity_To { get; set; }
        public string? Remarks { get; set; }
        public int? Agent_Status { get; set; }
        public string? NIDNo { get; set; }
        public string? TINNo { get; set; }
        public string? Agent_MobileNo { get; set; }
    }
}
