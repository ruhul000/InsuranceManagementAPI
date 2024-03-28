using InsuranceManagementAPI.CustomAttribute;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Shared")]
    [ApiVersion("1.0")]
    public class SharedAPIController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet("Invoice")]
        [ApiKey]
        public ActionResult<string> GetInvoice()
        {
            var response = "Authentication Successful";

            return Ok(response);
        }
    }
}
