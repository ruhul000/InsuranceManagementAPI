namespace InsuranceManagementAPI.Models
{
    public class InsuranceCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set;}
        public bool status { get; set; }
        public int? EUser { get; set; }
        public DateTime? EDate { get; set; }
        public int? UUser { get; set; }
        public DateTime? UDate { get; set; }
    }
}
