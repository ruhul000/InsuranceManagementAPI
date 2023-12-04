using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
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
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("GetAllBanks")]
        public ActionResult GetAllBanks(BankReportParam param)
        {
            ReportDocument file = _reportingService.GetBankList(param);
            return File(file.FileStream, MediaTypeNames.Application.Octet, file.FileName);
        }
    }
}
