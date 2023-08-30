using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/BankBranch")]
    [ApiVersion("1.0")]
    public class BankBranchController : ControllerBase
    {
        private readonly IBankBranchService _bankBranchService;
        public BankBranchController(IBankBranchService bankBranchService)
        { 
            _bankBranchService = bankBranchService;
        }

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpGet("BankBranches")]
        public ActionResult<IEnumerable<BankBranch>> GetAllBankBranches()
        {
            IEnumerable<BankBranch> response;
            try
            {
                response = _bankBranchService.GetAllBankBranches().Result;

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

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<BankBranch> CreateBank(BankBranch bankBranch)
        {
            BankBranch? response;
            try
            {
                response = _bankBranchService.Create(bankBranch).Result;

                if (response == null)
                {
                    return BadRequest("Branch creation failed!");
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
