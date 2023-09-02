using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data
{
    [Table("Bank")]
    public class BankDto
    {
        [Key]
        public int BankId { get; set; }
        
        public string BankName { get; set; }
    }
}
