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
        public virtual DbSet<BankBranchDto> BankBranch { get; set; }
        public virtual DbSet<UserDto> Users { get; set; }
        public virtual DbSet<RefreshTokenDto> RefreshTokens { get; set; }
        public virtual DbSet<ClientDto> Clients { get; set; }
        public virtual DbSet<InsurancebranchDto> InsuranceCompany { get; set; }
        public virtual DbSet<CompanyDto> Company { get; set; }
        public virtual DbSet<BranchDto> Branch{ get; set; }
    }
}
