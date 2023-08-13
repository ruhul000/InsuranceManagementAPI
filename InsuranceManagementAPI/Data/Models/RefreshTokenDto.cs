using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("RefreshToken")]
    public class RefreshTokenDto
    {
        [Key]
        public string UserName { get; set; }
        public string TokenID { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; }
    }
}
