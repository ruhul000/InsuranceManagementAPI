using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("tab_DepartmentInfo")]
    public class DepartmentDto
    {
        [Key]
        public int DepKey { get; set; }
        public string DepName { get; set; }
        public string? DepNameShort { get; set; }
        public int? DepOrderKey { get; set; }
    }
}
