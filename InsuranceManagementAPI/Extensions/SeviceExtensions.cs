using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Extensions
{
    public static class SeviceExtensions
    {
        public static void ConfigureDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PolicyDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("PolicyAPIConnectionString")));
        }

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBankRepository, BankRepository>();
        }

    }
}
