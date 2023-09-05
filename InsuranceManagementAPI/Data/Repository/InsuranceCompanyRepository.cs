using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class InsuranceCompanyRepository : IInsuranceCompanyRepository
    {
        private readonly PolicyDBContext _context;

        public InsuranceCompanyRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<Int32> Add(InsuranceCompanyDto insuranceCompanyDto)
        {
            int CompanyId = 0;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@CompanyId", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = insuranceCompanyDto.CompanyName.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@status", Value = insuranceCompanyDto.status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EntryUserID", Value = insuranceCompanyDto.EntryUserID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EntryTime", Value = DateTime.Now });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateUserID", Value = insuranceCompanyDto.UpdateUserID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateTime", Value = DateTime.Now });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE InsuranceCompanyAdd @CompanyId OUT, @CompanyName, @status, @EntryUserID, @EntryTime, @UpdateUserID, @UpdateTime", paramList);

                CompanyId = Convert.ToInt32(paramList[0].Value);
            }
            catch (Exception ex)
            {
            }
            return CompanyId;
        }

        public async Task<IEnumerable<InsuranceCompanyDto>> GetAll()
        {
            var result = _context.InsuranceCompany.FromSqlRaw<InsuranceCompanyDto>("EXECUTE GetAllInsuranceCompanies").ToList();


            return result;
        }

        public async Task<InsuranceCompanyDto> GetByID(int id)
        {
            var result = _context.InsuranceCompany.FromSqlRaw("EXECUTE GetInsuranceCompanyById {0}", id).AsEnumerable().FirstOrDefault();

            return result;
        }

        public async Task<bool> Remove(int companyId)
        {
            InsuranceCompanyDto insuranceCompanyDto = new InsuranceCompanyDto { CompanyId = companyId};
            _context.InsuranceCompany.Remove(insuranceCompanyDto);

            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> Update(InsuranceCompanyDto insuranceCompanyDto)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@CompanyId", Value = insuranceCompanyDto.CompanyId });
            paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = insuranceCompanyDto.CompanyName.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@status", Value = insuranceCompanyDto.status.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@UpdateUserID", Value = insuranceCompanyDto.UpdateUserID.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@UpdateTime", Value = DateTime.Now });


            await _context.Database.ExecuteSqlRawAsync("EXECUTE InsuranceCompanyUpdate @Result OUT,@CompanyId ,@CompanyName ,@status,@UpdateUserID ,@UpdateTime", paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }
    }
}
