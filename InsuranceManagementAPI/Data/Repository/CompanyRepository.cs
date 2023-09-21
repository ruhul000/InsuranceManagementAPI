using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PolicyDBContext _context;

        public CompanyRepository(PolicyDBContext context)
        {
            _context = context;
        }

        public async Task<Int32> Add(CompanyDto companyDto)
        {
            Int32 CompanyId = 0;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@ComKey", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = companyDto.CompanyName.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@ShortName", Value = companyDto.ShortName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Address", Value = companyDto.Address.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Phone", Value = companyDto.Phone.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Fax", Value = companyDto.Fax.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Mobile", Value = companyDto.Mobile.ToDBNullIfNothing() }); 
                paramList.Add(new SqlParameter { ParameterName = "@Email", Value = companyDto.Email.ToDBNullIfNothing()});
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlaceHO", Value = companyDto.IssuingPlaceHO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Web", Value = companyDto.Web.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Logo", Value = companyDto.Logo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@LHead", Value = companyDto.LHead.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = companyDto.BackupType.ToDBNullIfNothing() });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Company_Add @ComKey OUT, @CompanyName, @ShortName, @Address, @Phone, @Fax,@Mobile, @Email,@IssuingPlaceHO, @Web, @Logo, @LHead,@BackupType", paramList);

                CompanyId = Convert.ToInt32(paramList[0].Value);
            }
            catch (Exception ex)
            {
            }
            return CompanyId;
        }

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<CompanyDto> GetByID(int companyId)
        {
            return await _context.Company.FirstOrDefaultAsync(obj => obj.ComKey== companyId);
        }

        public async Task<bool> Remove(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CompanyDto companyDto)
        {
            bool result = false;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@ComKey", Value = companyDto.ComKey });
                paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = companyDto.CompanyName.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@ShortName", Value = companyDto.ShortName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Address", Value = companyDto.Address.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Phone", Value = companyDto.Phone.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Fax", Value = companyDto.Fax.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Mobile", Value = companyDto.Mobile.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Email", Value = companyDto.Email.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlaceHO", Value = companyDto.IssuingPlaceHO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Web", Value = companyDto.Web.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Logo", Value = companyDto.Logo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@LHead", Value = companyDto.LHead.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = companyDto.BackupType.ToDBNullIfNothing() });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Company_Update @result OUT, @ComKey, @CompanyName, @ShortName, @Address, @Phone, @Fax,@Mobile, @Email,@IssuingPlaceHO, @Web, @Logo, @LHead,@BackupType", paramList);

                result = Convert.ToBoolean(paramList[0].Value);
                
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
