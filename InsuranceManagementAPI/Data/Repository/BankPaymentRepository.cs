using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankPaymentRepository : IBankPaymentRepository
    {
        private readonly PolicyDBContext _context;

        public BankPaymentRepository(PolicyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Update(BankPaymentDto bankPaymentDto)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@FinalMRKey", Value = bankPaymentDto.FinalMRKey });
            


            await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Confirm_Bank_Payment @Result OUT, @FinalMRKey",
                paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }
    }
}
