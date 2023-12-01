using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly PolicyDBContext _context;

        public BranchRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(BranchDto branchDto)
        {
            Int32 BranchKey = 0;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@BranchKey", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@ComKey", Value = branchDto.ComKey });
                paramList.Add(new SqlParameter { ParameterName = "@BranchID", Value = branchDto.BranchID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchOrderKey", Value = branchDto.BranchOrderKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Open_Date", Value = branchDto.Branch_Open_Date.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = branchDto.BranchName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ShortName", Value = branchDto.ShortName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ZoneKey", Value = branchDto.ZoneKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Address", Value = branchDto.Address.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Address_2", Value = branchDto.Branch_Address_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Address_3", Value = branchDto.Branch_Address_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Phone", Value = branchDto.Phone.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Mobile", Value = branchDto.Mobile.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Fax", Value = branchDto.Fax.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EMail", Value = branchDto.EMail.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKeyIncharge", Value = branchDto.EmpKeyIncharge.ToDBNullIfNothing() });                
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace", Value = branchDto.IssuingPlace.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace_2", Value = branchDto.IssuingPlace_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace_3", Value = branchDto.IssuingPlace_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Computerized", Value = branchDto.Computerized.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Seal", Value = branchDto.Seal.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_A", Value = branchDto.Signatore_Name_A.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_A", Value = branchDto.Signatore_A.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_B", Value = branchDto.Signatore_Name_B.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_B", Value = branchDto.Signatore_B.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_C", Value = branchDto.Signatore_Name_C.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_C", Value = branchDto.Signatore_C.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Status", Value = branchDto.Status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = branchDto.BackupType.ToDBNullIfNothing() });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Branch_Add @BranchKey OUT, @ComKey, @BranchID, @BranchOrderKey, @Branch_Open_Date, @BranchName,@ShortName,@ZoneKey," +
                    " @Address,@Branch_Address_2,@Branch_Address_3,@Phone,@Mobile,@Fax,@EMail,@EmpKeyIncharge,@IssuingPlace,@IssuingPlace_2,@IssuingPlace_3,@Computerized,@Seal,@Signatore_Name_A,@Signatore_A," +
                    "@Signatore_Name_B,@Signatore_B,@Signatore_Name_C,@Signatore_C,@Status,@BackupType", paramList);

                BranchKey = Convert.ToInt32(paramList[0].Value);
            }
            catch (Exception ex)
            {
            }
            return BranchKey;
        }

        public async Task<IEnumerable<BranchDto>> GetAll()
        {
            return await _context.Branch.ToListAsync();
        }

        public async Task<IEnumerable<BranchDto>> GetAllByCompanyID(int ComKey)
        {
            return await _context.Branch.Where(x => x.ComKey == ComKey).ToListAsync();
        }

        public async Task<BranchDto> GetByID(int BranchKey)
        {
            return await _context.Branch.FirstOrDefaultAsync(x=>x.BranchKey == BranchKey);
        }

        public async Task<bool> Remove(int BranchKey)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(BranchDto branchDto)
        {
            Boolean result = false;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@BranchKey", Value = branchDto.BranchKey });
                paramList.Add(new SqlParameter { ParameterName = "@ComKey", Value = branchDto.ComKey });
                paramList.Add(new SqlParameter { ParameterName = "@BranchID", Value = branchDto.BranchID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchOrderKey", Value = branchDto.BranchOrderKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Open_Date", Value = branchDto.Branch_Open_Date.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = branchDto.BranchName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ShortName", Value = branchDto.ShortName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ZoneKey", Value = branchDto.ZoneKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Address", Value = branchDto.Address.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Address_2", Value = branchDto.Branch_Address_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Branch_Address_3", Value = branchDto.Branch_Address_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Phone", Value = branchDto.Phone.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Mobile", Value = branchDto.Mobile.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Fax", Value = branchDto.Fax.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EMail", Value = branchDto.EMail.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKeyIncharge", Value = branchDto.EmpKeyIncharge.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace", Value = branchDto.IssuingPlace.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace_2", Value = branchDto.IssuingPlace_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace_3", Value = branchDto.IssuingPlace_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Computerized", Value = branchDto.Computerized.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Seal", Value = branchDto.Seal.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_A", Value = branchDto.Signatore_Name_A.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_A", Value = branchDto.Signatore_A.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_B", Value = branchDto.Signatore_Name_B.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_B", Value = branchDto.Signatore_B.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_Name_C", Value = branchDto.Signatore_Name_C.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Signatore_C", Value = branchDto.Signatore_C.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Status", Value = branchDto.Status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = branchDto.BackupType.ToDBNullIfNothing() });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Branch_Update @Result OUT, @BranchKey , @ComKey, @BranchID, @BranchOrderKey, @Branch_Open_Date, @BranchName,@ShortName,@ZoneKey," +
                    " @Address,@Branch_Address_2,@Branch_Address_3,@Phone,@Mobile,@Fax,@EMail,@EmpKeyIncharge,@IssuingPlace,@IssuingPlace_2,@IssuingPlace_3,@Computerized,@Seal,@Signatore_Name_A,@Signatore_A," +
                    "@Signatore_Name_B,@Signatore_B,@Signatore_Name_C,@Signatore_C,@Status,@BackupType", paramList);

                result = Convert.ToBoolean(paramList[0].Value);
                
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
