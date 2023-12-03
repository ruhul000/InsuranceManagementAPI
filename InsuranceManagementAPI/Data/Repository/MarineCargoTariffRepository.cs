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
            List<MarineCargoTariffDto> result = new List<MarineCargoTariffDto>();
            try
            {
                result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff").ToList();
            }
            catch (Exception ex)
            {

            }            

            return result;
        }
        public async Task<IEnumerable<MarineCargoTariffDto>> GetItemNames(string TariffCategory, string RiskType)
        {


            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;2 " + "'"+ TariffCategory+"','"+ RiskType +"'" ).ToList();
            

            return result;
        }

        

        public async Task<IEnumerable<MarineCargoTariffDto>> GetTypeA(string TariffCategory, string RiskType, string ItemName)
        {
            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;3 {0},{1},{2}",TariffCategory,RiskType,ItemName).ToList();


            return result;
        }

        public async Task<IEnumerable<MarineCargoTariffDto>> GetTypeB(string TariffCategory, string RiskType, string ItemName, string TypeA)
        {
            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;4 {0},{1},{2},{3}", TariffCategory, RiskType, ItemName,TypeA).ToList();


            return result;
        }

        public async Task<IEnumerable<MarineCargoTariffDto>> GetTypeC(string TariffCategory, string RiskType, string ItemName, string TypeA, string TypeB)
        {
            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;5 {0},{1},{2},{3}, {4}", TariffCategory, RiskType, ItemName, TypeA, TypeB).ToList();


            return result;
        }

        public async Task<IEnumerable<MarineCargoTariffDto>> GetRate(string TariffCategory, string RiskType, string ItemName, string TypeA, string TypeB,String TypeC)
        {
            var result = _context.MarineCargoTariff.FromSqlRaw<MarineCargoTariffDto>("EXECUTE SpMC_Tariff;6 {0},{1},{2},{3}, {4},{5}", TariffCategory, RiskType, ItemName, TypeA, TypeB,TypeC).ToList();


            return result;
        }
    }
}
