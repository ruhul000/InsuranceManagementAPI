using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("tab_DesignationInfo")]
    public class DesignationDto
    {
        [Key]
        public int DegKey { get; set; }
        public String? Deg_Name { get; set; }
        public String? ShortDeg { get; set; }
        
        public String? GradeName { get; set; }
        public String? Salary_Scale { get; set; }
        public int? OrderKey { get; set; }
        
        
    }
}
