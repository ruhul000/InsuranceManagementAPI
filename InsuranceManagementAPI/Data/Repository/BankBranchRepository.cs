using InsuranceManagementAPI.Data.Models;
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
        public async Task<IEnumerable<BankBranchDto>> GetAllBankBranches()
        {
            //return await _context.BankBranch.ToListAsync();

           


            var result =  _context.BankBranch.FromSqlRaw<BankBranchDto>("EXECUTE GetAllBankBranches '', ''").ToList();


            
            return result;

        }

        public async Task<BankBranchDto> GetBankBranchById(int id)
        {
            return await _context.BankBranch.FirstOrDefaultAsync(obj => obj.BranchId == id);
        }

        public async Task<IEnumerable<BankBranchDto>> GetBankBranches(int bankId)
        {
            return await _context.BankBranch.Where(obj => obj.BankId == bankId).ToListAsync();
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
                paramList.Add(new SqlParameter { ParameterName = "@Status", Value = bankBranch.Status });
                paramList.Add(new SqlParameter { ParameterName = "@EntryUserID", Value = bankBranch.EntryUserID });
                paramList.Add(new SqlParameter { ParameterName = "@EntryTime", Value = DateTime.Now });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateUserID", Value = bankBranch.UpdateUserID });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateTime", Value = DateTime.Now });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE BankBranchAdd @BranchId OUT, @BranchName, @BankId, @BranchAddress, @SwiftCode, @RoutingNumber, @Status, @EntryUserID, @EntryTime, @UpdateUserID, @UpdateTime",    paramList);

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

       
    }
}
