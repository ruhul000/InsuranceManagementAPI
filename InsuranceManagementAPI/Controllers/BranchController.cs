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
    [Route("api/v{version:apiVersion}/Branch")]
    [ApiVersion("1.0")]
    public class BranchController : ControllerBase
    {

        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Branch> Create(Branch branch)
        {
            Branch? response;
            try
            {
                response = _branchService.Create(branch).Result;

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
        [HttpGet("Branches")]
        public ActionResult<IEnumerable<Branch>> GetAll()
        {
            IEnumerable<Branch> response;
            try
            {
                response = _branchService.GetAll().Result;

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
        [HttpGet("company/{ComKey}")]
        public ActionResult<IEnumerable<Branch>> GetAllByCompanyId(int ComKey)
        {
            IEnumerable<Branch> response;
            try
            {
                response = _branchService.GetAllByCompanyID(ComKey).Result;

                if (response == null)
                {
                    return NotFound();
                }
                else if(response.Count()==0)
                {
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{BranchKey}")]
        public ActionResult<Branch> GetById(int BranchKey)
        {
            Branch? response;
            try
            {
                response = _branchService.GetById(BranchKey).Result;

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
        public ActionResult<Branch> Update(Branch branch)
        {
            Branch? response;
            try
            {
                response = _branchService.Update(branch).Result;

                if (response == null)
                {
                    return BadRequest("Branch update failed!");
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
