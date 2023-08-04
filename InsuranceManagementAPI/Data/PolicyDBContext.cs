using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data
{
    public class PolicyDBContext : DbContext
    {
        public PolicyDBContext(DbContextOptions<PolicyDBContext> options) : base(options)
        {
        }
        public virtual DbSet<BankDto> Bank { get; set; }

        public virtual DbSet<UserDto> Users { get; set; }
    }
}
