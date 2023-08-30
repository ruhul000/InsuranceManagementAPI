namespace InsuranceManagementAPI.Models
{
    public class BankBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int BankId { get; set; }
        public string BranchAddress { get; set; }
        public String SwiftCode { get; set; } 
        public String RoutingNumber { get; set; }
        public bool Status { get; set; }
        public int EntryUserID { get; set; }
        public DateTime EntryTime { get; set; } 
        public int UpdateUserID { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
