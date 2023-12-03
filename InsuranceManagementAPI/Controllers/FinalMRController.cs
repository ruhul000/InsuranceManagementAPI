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


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<FinalMR> Create(FinalMR finalMR)
        {

            FinalMR? response;
            try
            {
                //validation part
                if(finalMR.ClientKey == 0 || finalMR.ClientKey == null)
                {
                    return BadRequest("Select a Client");
                }

                response = _finalMRService.Create(finalMR).Result;

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
