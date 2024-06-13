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
        public virtual DbSet<DepartmentDto> Department{ get; set; }
        public virtual DbSet<DesignationDto> Designation { get; set; }
        public virtual DbSet<EmployeeDto> Employee { get; set; }
        public virtual DbSet<AgentDto> Agent { get; set; }
        public virtual DbSet<CurrencyDto> Currency{ get; set; }
        public virtual DbSet<MarineCargoTariffDto> MarineCargoTariff { get; set; }
        public virtual DbSet<FinalMRDto> FinalMR{ get; set; }
        public virtual DbSet<MediclaimTariffDto> MediclaimTariff { get; set; }
        public virtual DbSet<MotorTariffDto> MotorTariff { get; set; }

    }
}
