using InsuranceManagementAPI.CustomAttribute;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/BankPayment")]
    [ApiVersion("1.0")]

    public class BankPaymentController : ControllerBase
    {        
        private readonly IBankPaymentService _bankPaymentService;
        private readonly IFinalMRService _finalMRService;
        public BankPaymentController(IBankPaymentService bankPaymentService, IFinalMRService finalMrService)
        {     
            _bankPaymentService = bankPaymentService;
            _finalMRService = finalMrService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("Confirm")]
        [ApiKey]
        public ActionResult<bool> Confirm(BankPayment bankPayment)
        {
            bool response = false;
            try
            {
                FinalMR finalMR = _finalMRService.GetFinalMRByKey(Convert.ToInt64(bankPayment.Reference.Substring(4))).Result;
                if (finalMR.MRNetPremium == bankPayment.Amount)
                {
                    response = _bankPaymentService.Update(bankPayment).Result;
                }

                 if (response == null)
                 {
                     return BadRequest("Payment Update Failed");
                 }
                
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


    }
}
