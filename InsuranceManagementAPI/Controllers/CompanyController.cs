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


        [EnableCors("Policy")]
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
    }
}
