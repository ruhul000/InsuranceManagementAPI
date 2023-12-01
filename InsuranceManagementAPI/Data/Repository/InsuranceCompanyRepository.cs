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
        public async Task<Int32> Add(InsurancebranchDto insurancebranchDto)
        {
            int CompanyId = 0;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@CompanyId", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = insurancebranchDto.CompanyName.ToString() });
                paramList.Add(new SqlParameter { ParameterName = "@status", Value = insurancebranchDto.status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EntryUserID", Value = insurancebranchDto.EntryUserID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EntryTime", Value = DateTime.Now });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateUserID", Value = insurancebranchDto.UpdateUserID.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@UpdateTime", Value = DateTime.Now });

                await _context.Database.ExecuteSqlRawAsync("EXECUTE InsuranceCompanyAdd @CompanyId OUT, @CompanyName, @status, @EntryUserID, @EntryTime, @UpdateUserID, @UpdateTime", paramList);

                CompanyId = Convert.ToInt32(paramList[0].Value);
            }
            catch (Exception ex)
            {
            }
            return CompanyId;
        }

        public async Task<IEnumerable<InsurancebranchDto>> GetAll()
        {
            var result = _context.InsuranceCompany.FromSqlRaw<InsurancebranchDto>("EXECUTE GetAllInsuranceCompanies").ToList();


            return result;
        }

        public async Task<InsurancebranchDto> GetByID(int id)
        {
            var result = _context.InsuranceCompany.FromSqlRaw("EXECUTE GetInsuranceCompanyById {0}", id).AsEnumerable().FirstOrDefault();

            return result;
        }

        public async Task<bool> Remove(int companyId)
        {
            InsurancebranchDto insurancebranchDto = new InsurancebranchDto { CompanyId = companyId};
            _context.InsuranceCompany.Remove(insurancebranchDto);

            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> Update(InsurancebranchDto insurancebranchDto)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@CompanyId", Value = insurancebranchDto.CompanyId });
            paramList.Add(new SqlParameter { ParameterName = "@CompanyName", Value = insurancebranchDto.CompanyName.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@status", Value = insurancebranchDto.status.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@UpdateUserID", Value = insurancebranchDto.UpdateUserID.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@UpdateTime", Value = DateTime.Now });


            await _context.Database.ExecuteSqlRawAsync("EXECUTE InsuranceCompanyUpdate @Result OUT,@CompanyId ,@CompanyName ,@status,@UpdateUserID ,@UpdateTime", paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }
    }
}
