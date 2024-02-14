using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class MediclaimTariffRepository : IMediclaimTariffRepository
    {
        private readonly PolicyDBContext _context;

        public MediclaimTariffRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MediclaimTariffDto>> GetTravelRate(int Days, int Age, int Tariff_Type, int Travel_Type)
        {
            
            try
            {
               var result = _context.MediclaimTariff.FromSqlRaw<MediclaimTariffDto>("EXECUTE SpMediclaim_Travel_Tariff {0}, {1}, {2} , {3}", Days, Age, Tariff_Type,Travel_Type ).ToList();

               return result;  
                
            }
            catch (Exception ex) { }
            return null;
            
        }
    }
}
