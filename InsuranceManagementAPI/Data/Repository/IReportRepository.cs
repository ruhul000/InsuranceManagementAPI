using InsuranceManagementAPI.Models.Report;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IReportRepository
    {
        Task<DataSet> GetBankReportDataSet(int branchKey);
        Task<DataSet> GetFinalMRReportDataSet(FinalMRReportParam param);
    }
}
