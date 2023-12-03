using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Extensions;
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

        [MapToApiVersion("1.0")]
        [HttpGet("{bankId}")]
        public ActionResult<Bank> GetBankByID(int bankId)
        {
            Bank? response;
            try
            {
                response = _bankService.GetBankById(bankId).Result;

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
        public ActionResult<Bank> Update(Bank bank)
        {
            Bank? response;
            try
            {
                var userId = AuthExtensions.GetClaimsUserId(HttpContext);

                response = _bankService.Update(bank, userId).Result;

                if (response == null)
                {
                    return BadRequest("Bank update failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Bank> CreateBank(Bank bank)
        {
            Bank? response;
            try
            {
                var userId = AuthExtensions.GetClaimsUserId(HttpContext);

                response = _bankService.Create(bank, userId).Result;

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

        [MapToApiVersion("1.0")]
        [HttpDelete("Delete")]
        public ActionResult<bool>DeleteBank(int  bankId)
        {
            bool deleted;
            try
            {
                deleted = _bankService.Delete(bankId).Result;

                if (!deleted)
                {
                    return BadRequest("Bank delete failed!");
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
