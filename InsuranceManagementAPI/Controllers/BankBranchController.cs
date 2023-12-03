using InsuranceManagementAPI.Extensions;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
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

        
        [MapToApiVersion("1.0")]
        [HttpPost("Search")]
        public ActionResult<IEnumerable<BankBranch>> GetAllBankBranches(BankBranch bankBranch)
        {
            IEnumerable<BankBranch> response;
            try
            {                
                response = _bankBranchService.GetAllBankBranches(bankBranch).Result;

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
        [HttpGet("BankBranches/{BankId}")]
        public ActionResult<IEnumerable<BankBranch>> GetBankBranches(int BankId)
        {
            IEnumerable<BankBranch> response;
            try
            {
                response = _bankBranchService.GetBankBranches(BankId).Result;

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
        [HttpGet("{BranchId}")]
        public ActionResult<BankBranch> GetBankBranchById(int BranchId)
        {
            BankBranch? response;
            try
            {
                response = _bankBranchService.GetBankBranchById(BranchId).Result;

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
        [HttpPost("Create")]
        public ActionResult<BankBranch> CreateBranch(BankBranch bankBranch)
        {
            BankBranch? response;
            try
            {
                var userId = AuthExtensions.GetClaimsUserId(HttpContext);
                bankBranch.EUser = userId;
                bankBranch.UUser = userId;

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

        
        [MapToApiVersion("1.0")]
        [HttpPut("Update")]
        public ActionResult<BankBranch> Update(BankBranch bankBranch)
        {
            BankBranch? response;
            try
            {
                var userId = AuthExtensions.GetClaimsUserId(HttpContext);
                bankBranch.EUser = userId;
                bankBranch.UUser = userId;

                response = _bankBranchService.Update(bankBranch).Result;

                if (response == null)
                {
                    return BadRequest("Bank Branch update failed!");
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
        public ActionResult DeleteClient(int branchId)
        {
            bool deleted;
            try
            {
                deleted = _bankBranchService.Delete(branchId).Result;

                if (!deleted)
                {
                    return BadRequest("Client deleted failed!");
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
