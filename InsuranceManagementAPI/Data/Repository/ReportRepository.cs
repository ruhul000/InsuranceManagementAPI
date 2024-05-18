using InsuranceManagementAPI.Models.Report;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceManagementAPI.Data.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConfiguration _configuration;
        string ConnectionString = "";  
        public ReportRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("PolicyAPIConnectionString");
        }
        public DataTable GetBranchByIdDataTable(int branchKey)
        {
            string connectionString = _configuration.GetConnectionString("PolicyAPIConnectionString");

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from tab_BranchInfo where BranchKey=" + branchKey, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public async Task<DataSet> GetBankReportDataSet(int branchKey)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "rptGetAllBank";
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Another approach to add Input Parameter
                        cmd.Parameters.AddWithValue("@BranchKey", branchKey);

                        connection.Open();
       

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        connection.Close();

                        //ds.Tables[0].TableName = "dtBanks";
                        //ds.Tables[1].TableName = "dtBranch";
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public async Task<DataSet> GetFinalMRReportDataSet(FinalMRReportParam param)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                // Get FinalMR
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_Final_MR WHERE FinalMRKey=" + param.FinalMRKey, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtFinalMR = new DataTable { TableName = "dtFinalMR" };
                da.Fill(dtFinalMR);
                ds.Tables.Add(dtFinalMR);

                DataTable dtBranchInfo = null;
                DataTable dtBankBranch = null;
                DataTable dtBank = null;
                DataTable dtClient = null;
                // Get BranchInfo
                try
                {
                    var BranchKey = dtFinalMR.Rows[0]["BranchKey"].ToString();

                    cmd = new SqlCommand("SELECT * FROM tab_BranchInfo WHERE BranchKey=" + BranchKey, con);
                    da = new SqlDataAdapter(cmd);
                    dtBranchInfo = new DataTable { TableName = "dtBranchInfo" };
                    da.Fill(dtBranchInfo);
                    ds.Tables.Add(dtBranchInfo);
                }catch(Exception ex) { }

                // Get BankBranch
                try
                {
                    var BankBranchKey = dtFinalMR.Rows[0]["BankKey"].ToString();

                    cmd = new SqlCommand("SELECT * FROM BankBranch WHERE BranchId=" + BankBranchKey, con);
                    da = new SqlDataAdapter(cmd);
                    dtBankBranch = new DataTable { TableName = "dtBankBranch" };
                    da.Fill(dtBankBranch);
                    ds.Tables.Add(dtBankBranch);
                }catch (Exception ex) { }

                // Get Bank
                try
                {
                    var BankID = dtBankBranch.Rows[0]["BankId"].ToString();

                    cmd = new SqlCommand("SELECT * FROM Bank WHERE BankId=" + BankID, con);
                    da = new SqlDataAdapter(cmd);
                    dtBank = new DataTable { TableName = "dtBank" };
                    da.Fill(dtBank);
                    ds.Tables.Add(dtBank);
                }catch(Exception ex) { }

                //Get Client

                try
                {
                    var ClientKey = dtFinalMR.Rows[0]["ClientKey"].ToString();

                    cmd = new SqlCommand("SELECT * FROM tab_Client WHERE ClientKey=" + ClientKey, con);
                    da = new SqlDataAdapter(cmd);
                    dtClient = new DataTable { TableName = "dtClient" };
                    da.Fill(dtClient);
                    ds.Tables.Add(dtClient);
                }
                catch (Exception ex) { }
                con.Close();

            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
    }
}
