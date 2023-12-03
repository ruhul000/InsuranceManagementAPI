using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Employee")]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Employee> Create(Employee employee)
        {

            Employee? response;
            try
            {
                response = _employeeService.Create(employee).Result;

                if (response == null)
                {
                    return BadRequest("Employee creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("Employees")]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {

            IEnumerable<Employee> response;
            try
            {
                response = _employeeService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response = new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{EmpKey}")]
        public ActionResult<Employee> GetByID(int EmpKey)
        {
            Employee? response;
            try
            {
                response = _employeeService.GetById(EmpKey).Result;

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
        public ActionResult<Employee> Update(Employee employee)
        {
            Employee? response;
            try
            {
                response = _employeeService.Update(employee).Result;

                if (response == null)
                {
                    return BadRequest("Employee update failed!");
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
