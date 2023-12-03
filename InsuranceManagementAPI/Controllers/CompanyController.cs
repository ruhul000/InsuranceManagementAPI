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
    [Route("api/v{version:apiVersion}/Company")]
    [ApiVersion("1.0")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Company> Create(Company Company)
        {            

            Company? response;
            try
            {
                response = _companyService.Create(Company).Result;

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
        [HttpGet("Companies")]
        public ActionResult<IEnumerable<Company>> GetAll()
        {

            IEnumerable<Company> response;
            try
            {
                response = _companyService.GetAll().Result;

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
        [HttpGet("{ComKey}")]
        public ActionResult<Company> GetByID(int ComKey)
        {
            Company? response;
            try
            {
                response = _companyService.GetById(ComKey).Result;

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
        public ActionResult<Company> Update(Company company)
        {
            Company? response;
            try
            {
                response = _companyService.Update(company).Result;

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
    }
}
