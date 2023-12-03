using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Designation")]
    [ApiVersion("1.0")]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Designation> Create(Designation Designation)
        {

            Designation? response;
            try
            {
                response = _designationService.Create(Designation).Result;

                if (response == null)
                {
                    return BadRequest("Designation creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("Designations")]
        public ActionResult<IEnumerable<Designation>> GetAll()
        {

            IEnumerable<Designation> response;
            try
            {
                response = _designationService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response = new List<Designation>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{DesKey}")]
        public ActionResult<Designation> GetByID(int DesKey)
        {
            Designation? response;
            try
            {
                response = _designationService.GetById(DesKey).Result;

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
        public ActionResult<Designation> Update(Designation designation)
        {
            Designation? response;
            try
            {
                response = _designationService.Update(designation).Result;

                if (response == null)
                {
                    return BadRequest("Designation update failed!");
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
