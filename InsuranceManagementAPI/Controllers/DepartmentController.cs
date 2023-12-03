using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Department")]
    [ApiVersion("1.0")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Department> Create(Department department)
        {

            Department? response;
            try
            {
                response = _departmentService.Create(department).Result;

                if (response == null)
                {
                    return BadRequest("Department creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("Departments")]
        public ActionResult<IEnumerable<Department>> GetAll()
        {

            IEnumerable<Department> response;
            try
            {
                response = _departmentService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response= new List<Department>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{DepKey}")]
        public ActionResult<Department> GetByID(int DepKey)
        {
            Department? response;
            try
            {
                response = _departmentService.GetById(DepKey).Result;

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
        public ActionResult<Department> Update(Department department)
        {
            Department? response;
            try
            {
                response = _departmentService.Update(department).Result;

                if (response == null)
                {
                    return BadRequest("Department update failed!");
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
