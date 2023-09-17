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
                paramList.Add(new SqlParameter { ParameterName = "@CompanyId", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@Name", Value = companyDto.Name.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@ShortCode", Value = companyDto.ShortCode.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Address", Value = companyDto.Address.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Phone", Value = companyDto.Phone.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Fax", Value = companyDto.Fax.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MobileNo", Value = companyDto.Fax.ToDBNullIfNothing() }); 
                paramList.Add(new SqlParameter { ParameterName = "@Email", Value = companyDto.Email.ToDBNullIfNothing()});
                paramList.Add(new SqlParameter { ParameterName = "@IssuingPlace", Value = companyDto.IssuingPlace.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Web", Value = companyDto.Web.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Logo", Value = companyDto.Logo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Banner", Value = companyDto.Banner.ToDBNullIfNothing() });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Company_Add @CompanyId OUT, @Name, @ShortCode, @Address, @Phone, @Fax,@MobileNo, @Email,@IssuingPlace, @Web, @Logo, @Banner", paramList);

                CompanyId = Convert.ToInt32(paramList[0].Value);
            }
            catch (Exception ex)
            {
            }
            return CompanyId;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllBanks()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyDto> GetBankByID(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CompanyDto bankDto)
        {
            throw new NotImplementedException();
        }
    }
}
