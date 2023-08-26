using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Bank")]
    [ApiVersion("1.0")]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpGet("Banks")]
        public  ActionResult<IEnumerable<Bank>> GetAllBanks()
        {
            IEnumerable<Bank> response;
            try
            {
                response = _bankService.GetAllBanks().Result;
                
                if(response == null || !response.Any())
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

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Bank> CreateBank(Bank bank)
        {
            Bank? response;
            try
            {
                response = _bankService.Create(bank).Result;

                if (response == null)
                {
                    return BadRequest("Bank creation failed!");
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
