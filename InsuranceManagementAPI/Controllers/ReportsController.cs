using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Mime;


namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Bank")]
    [ApiVersion("1.0")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("GetAllBanks")]
        public ActionResult GetAllBanks(BankReportParam param)
        {
            ReportDocument file;

            try
            {
                file = _reportingService.GetBankList(param);

                if (file.FilePath.IsNullOrEmpty())
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(file);
        }
    }
}
