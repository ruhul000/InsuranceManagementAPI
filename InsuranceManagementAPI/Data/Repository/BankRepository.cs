using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly PolicyDBContext _context;

        public BankRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BankDto>> GetAllBanks()
        {
            List<BankDto> banks = new List<BankDto>();
            try
            {
                banks = await _context.Bank.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return banks;
        }
        public async Task<BankDto> GetBankByID(long id)
        {
            return await _context.Bank.FirstOrDefaultAsync(obj => obj.BankId == id);
        }
        public async Task<bool> Add(BankDto bank, int userId)
        {
            bank.EUser = userId;
            bank.EDate = DateTime.Now;

            _context.Bank.Add(bank);
            return (await _context.SaveChangesAsync() > 0);
        }
        public async Task<bool> Update(BankDto bank, int userId)
        {
            bank.UUser = userId;
            bank.UDate = DateTime.Now;

            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@BankId", Value = bank.BankId});
            paramList.Add(new SqlParameter { ParameterName = "@BankName", Value = bank.BankName });
            paramList.Add(new SqlParameter { ParameterName = "@UUser", Value = bank.UUser });
            

            await _context.Database.ExecuteSqlRawAsync("EXECUTE BankUpdate @Result OUT, @BankId, @BankName, @UUser",
                paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }
        public async Task<bool> Remove(int bankId)
        {
            BankDto bankDto = new BankDto { BankId = bankId };
            _context.Bank.Remove(bankDto);

            return (_context.SaveChanges() > 0);
        }
    }
}
