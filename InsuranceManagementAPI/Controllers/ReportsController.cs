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
    [Route("api/v{version:apiVersion}/Reports")]
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
                file = _reportingService.GenerateBankReport(param);

                if (file.FilePath.IsNullOrEmpty())
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           return File(file.FileStream, MediaTypeNames.Application.Octet, file.FileName);
            //return Ok(file);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("ReportFinalMR")]
        public ActionResult GenerateReportFinalMR(FinalMRReportParam param)
        {
            ReportDocument file;

            try
            {
                file = _reportingService.ReportFinalMR(param);

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

        [MapToApiVersion("1.0")]
        [HttpPost("FinalMRReport")]
        public ActionResult GenerateFinalMRReport(FinalMRReportParam param)
        {
            ReportDocument file = _reportingService.ReportFinalMR(param);

            return File(file.FileStream, MediaTypeNames.Application.Pdf, file.FileName);
        }


        [MapToApiVersion("1.0")]
        [HttpGet("OMPReport/{finalMRKey}")]
        public ActionResult GenerateOMPReport(int finalMRKey)
        {
            FinalMRReportParam param = new FinalMRReportParam();
            param.FinalMRKey = finalMRKey;

            ReportDocument file = _reportingService.ReportOMP(param);

            return File(file.FileStream, MediaTypeNames.Application.Pdf, file.FileName);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("ReportOMP")]
        public ActionResult GenerateReportOMP(FinalMRReportParam param)
        {
            ReportDocument file;

            try
            {
                file = _reportingService.ReportOMP(param);

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

        [MapToApiVersion("1.0")]
        [HttpGet("MotorReport/{finalMRKey}")]
        public ActionResult GenerateMotorReport(int finalMRKey)
        {
            FinalMRReportParam param = new FinalMRReportParam();
            param.FinalMRKey = finalMRKey;

            ReportDocument file = _reportingService.ReportMotor(param);

            return File(file.FileStream, MediaTypeNames.Application.Pdf, file.FileName);
        }
    }
}
