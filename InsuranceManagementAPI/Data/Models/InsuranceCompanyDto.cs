using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{    
    [Table("InsuranceCompany")]
    public class InsurancebranchDto
    {   
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool status { get; set; }
        public int? EntryUserID { get; set; }
        public DateTime? EntryTime { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
