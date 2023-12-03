using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BankBranchRepository:IBankBranchRepository
    {
        private readonly PolicyDBContext _context;

        public BankBranchRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BankBranchDto>> GetAllBankBranches(BankBranchDto bankBranchDto)
        {
            //return await _context.BankBranch.ToListAsync();

           


            var result =  _context.BankBranch.FromSqlRaw<BankBranchDto>("EXECUTE GetAllBankBranches {0}, {1}", bankBranchDto.BankName, bankBranchDto.BranchName).ToList();


            
            return result;

        }

        public async Task<BankBranchDto> GetBankBranchById(int id)
        {
            //return await _context.BankBranch.FirstOrDefaultAsync(obj => obj.BranchId == id);

            var result = _context.BankBranch.FromSqlRaw("EXECUTE GetBankBranchById {0}", id).AsEnumerable().FirstOrDefault();

            return result;
        }
    
        public async Task<IEnumerable<BankBranchDto>> GetBankBranches(int bankId)
        {
            //return await _context.BankBranch.Where(obj => obj.BankId == bankId).ToListAsync();
            var result = _context.BankBranch.FromSqlRaw<BankBranchDto>("EXECUTE GetBankBranches {0}", bankId).ToList();



            return result;
        }
        

        public async Task<int> Add(BankBranchDto bankBranch)
        {
            //_context.BankBranch.Add(bankBranch);
            //return (await _context.SaveChangesAsync() > 0);
            int BranchId = 0;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@BranchId", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });                
                paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = bankBranch.BranchName.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@BankId", Value = bankBranch.BankId });
                paramList.Add(new SqlParameter { ParameterName = "@BranchAddress", Value = bankBranch.BranchAddress.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@SwiftCode", Value = bankBranch.SwiftCode.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@RoutingNumber", Value = bankBranch.RoutingNumber.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@Status", Value = bankBranch.Status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EUser", Value = bankBranch.EUser });                
                paramList.Add(new SqlParameter { ParameterName = "@UUser", Value = bankBranch.UUser });
                

                await _context.Database.ExecuteSqlRawAsync("EXECUTE BankBranchAdd @BranchId OUT,  @BranchName, @BankId,  @BranchAddress, @SwiftCode, @RoutingNumber, @Status, @EUser, @UUser ",    paramList);

                BranchId = Convert.ToInt32(paramList[0].Value);
            }
            catch(Exception ex) 
            { 
            }
            return BranchId;

        }

        public async Task<bool> Remove(int branchId)
        {
            BankBranchDto bankBranchDto = new BankBranchDto { BranchId = branchId};
            _context.BankBranch.Remove(bankBranchDto);

            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> Update(BankBranchDto bankBranchDto)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@BranchId", Value = bankBranchDto.BranchId });
            paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = bankBranchDto.BranchName });            
            paramList.Add(new SqlParameter { ParameterName = "@BankId", Value = bankBranchDto.BankId });
            paramList.Add(new SqlParameter { ParameterName = "@BranchAddress", Value = bankBranchDto.BranchAddress });
            paramList.Add(new SqlParameter { ParameterName = "@SwiftCode", Value = bankBranchDto.SwiftCode });
            paramList.Add(new SqlParameter { ParameterName = "@RoutingNumber", Value = bankBranchDto.RoutingNumber });
            paramList.Add(new SqlParameter { ParameterName = "@Status", Value = bankBranchDto.Status.ToDBNullIfNothing()});
            paramList.Add(new SqlParameter { ParameterName = "@UUser", Value = bankBranchDto.UUser });
            


            await _context.Database.ExecuteSqlRawAsync("EXECUTE BankBranchUpdate @Result OUT,@BranchId ,@BranchName ,@BankId,@BranchAddress ,@SwiftCode ,@RoutingNumber ,@Status ,@UUser ", paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }
    }
}
