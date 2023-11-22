using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/FinalMR")]
    [ApiVersion("1.0")]
    public class FinalMRController : ControllerBase
    {
        private readonly IFinalMRService _finalMRService;
        public FinalMRController(IFinalMRService finalMRService)
        {
            _finalMRService = finalMRService;
        }


        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<FinalMR> Create(FinalMR FinalMR)
        {

            FinalMR? response;
            try
            {
                response = _finalMRService.Create(FinalMR).Result;

                if (response == null)
                {
                    return BadRequest("FinalMR creation failed!");
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
