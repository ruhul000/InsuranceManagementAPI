using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("BankBranch")]
    public class BankBranchDto
    {
        [Key]
        public int BranchId { get; set; }
        public string? BranchName { get; set; } = string.Empty;      
        public string? BankName { get; set; } = string.Empty;
        public int? BankId { get; set; }
        public string? BranchAddress { get; set; } = string.Empty;
        public String? SwiftCode { get; set; } = String.Empty;
        public String? RoutingNumber { get; set; } = String.Empty;
        
        public bool? Status { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }
        public int? UUser { get; set; }
        public DateTime? UDate { get; set; }
    }
}
