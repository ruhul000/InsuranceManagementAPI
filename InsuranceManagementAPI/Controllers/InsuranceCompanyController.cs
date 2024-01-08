using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/InsuranceCompany")]
    [ApiVersion("1.0")]
    public class InsuranceCompanyController : ControllerBase
    {
        private readonly IInsuranceCompanyService _insuranceCompanyService;
        public InsuranceCompanyController(IInsuranceCompanyService insuranceCompanyService)
        {
            _insuranceCompanyService = insuranceCompanyService;
        }

        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<InsuranceCompany> Create(InsuranceCompany insuranceCompany)
        {
            insuranceCompany.EDate = DateTime.Now;
            insuranceCompany.UDate = DateTime.Now;
            insuranceCompany.EUser = 1;
            insuranceCompany.UUser = 1;
            
            InsuranceCompany? response;
            try
            {
                response = _insuranceCompanyService.Create(insuranceCompany).Result;

                if (response == null)
                {
                    return BadRequest("Company creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("InsuranceCompanies")]
        public ActionResult<IEnumerable<InsuranceCompany>> GetAll()
        {
            IEnumerable<InsuranceCompany> response;
            try
            {
                response = _insuranceCompanyService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{companyId}")]
        public ActionResult<InsuranceCompany> GetByID(int companyId)
        {
            InsuranceCompany? response;
            try
            {
                response = _insuranceCompanyService.GetById(companyId).Result;

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpPut("Update")]
        public ActionResult<InsuranceCompany> Update(InsuranceCompany insuranceCompany)
        {
            InsuranceCompany? response;
            try
            {
                response = _insuranceCompanyService.Update(insuranceCompany).Result;

                if (response == null)
                {
                    return BadRequest("Company update failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        
        [MapToApiVersion("1.0")]
        [HttpDelete("Delete")]
        public ActionResult<bool> DeleteBank(int companyId)
        {
            bool deleted;
            try
            {
                deleted = _insuranceCompanyService.Delete(companyId).Result;

                if (!deleted)
                {
                    return BadRequest("Company delete failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(deleted);

        }



    }
}
