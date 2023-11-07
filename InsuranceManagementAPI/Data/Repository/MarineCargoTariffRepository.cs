using InsuranceManagementAPI.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class MarineCargoTariffRepository : IMarineCargoTariffRepository
    {
        private readonly PolicyDBContext _context;

        public MarineCargoTariffRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MarineCargoTariffDto>> GetTariffCategories()
        {
            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff").ToList();

            return result;
        }
        public async Task<IEnumerable<MarineCargoTariffDto>> GetItemNames(string TariffCategory, string RiskType)
        {
            var paramList = new List<SqlParameter>();            
            paramList.Add(new SqlParameter { ParameterName = "@Tariff_Catagory", Value = TariffCategory });
            paramList.Add(new SqlParameter { ParameterName = "@TypeOfRisk", Value = RiskType});

            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;2 @Tariff_Catagory,@TypeOfRisk", paramList).ToList();

            return result;
        }

        

        public Task<IEnumerable<MarineCargoTariffDto>> GetTypeA(string TariffCategory, string RiskType, string ItemName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarineCargoTariffDto>> GetTypeB(string TariffCategory, string RiskType, string ItemName, string TypeA)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarineCargoTariffDto>> GetTypeC(string TariffCategory, string RiskType, string ItemName, string TypeA, string TypeB)
        {
            throw new NotImplementedException();
        }
    }
}
