using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Report;
using InsuranceManagementAPI.Services;
using InsuranceManagementAPI.Services.PaymentGateway;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace InsuranceManagementAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SSLPaymentController : ControllerBase
    {
        private readonly IFinalMRService _finalMRService;
        private readonly IReportingService _reportingService;
        public SSLPaymentController(IFinalMRService finalMRService, IReportingService reportingService)
        {
            _finalMRService = finalMRService;
            _reportingService = reportingService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("Checkout/{transId}")]
        public IActionResult Checkout(int transId)
        {
            var productName = "Overseas Mediclaim Health Plan";

            FinalMR finalMR = _finalMRService.GetFinalMRByKey(transId).Result;
            var price = 1603;

            var baseUrl = Request.Scheme + "://" + Request.Host;



            // CREATING LIST OF POST DATA
            NameValueCollection PostData = new NameValueCollection();

            PostData.Add("total_amount", $"{finalMR.MRNetPremium}");
            PostData.Add("tran_id", $"{transId}");
            PostData.Add("success_url", baseUrl + "/api/v1/SSLPayment/CheckoutConfirmation");
            PostData.Add("fail_url", baseUrl + "/api/v1/SSLPayment/CheckoutFail");
            PostData.Add("cancel_url", baseUrl + "/api/v1/SSLPayment/CheckoutCancel");

            PostData.Add("version", "3.00");
            PostData.Add("cus_name", $"{finalMR.Text_Field_2} {finalMR.Text_Field_3}");
            PostData.Add("cus_email", $"{finalMR.Text_Field_7}");
            PostData.Add("cus_add1", "Address Line One");
            PostData.Add("cus_add2", "Address Line Two");
            PostData.Add("cus_city", "City Nam");
            PostData.Add("cus_state", "State Nam");
            PostData.Add("cus_postcode", "Post Cod");
            PostData.Add("cus_country", "Countr");
            PostData.Add("cus_phone", "0111111111");
            PostData.Add("cus_fax", "0171111111");
            PostData.Add("ship_name", "ABC XY");
            PostData.Add("ship_add1", "Address Line On");
            PostData.Add("ship_add2", "Address Line Tw");
            PostData.Add("ship_city", "City Nam");
            PostData.Add("ship_state", "State Nam");
            PostData.Add("ship_postcode", "Post Cod");
            PostData.Add("ship_country", "Countr");
            PostData.Add("value_a", "ref00");
            PostData.Add("value_b", "ref00");
            PostData.Add("value_c", "ref00");
            PostData.Add("value_d", "ref00");
            PostData.Add("shipping_method", "NO");
            PostData.Add("num_of_item", "1");
            PostData.Add("product_name", $"{productName}");
            PostData.Add("product_profile", "general");
            PostData.Add("product_category", "Demo");

            //we can get from email notificaton
            var storeId = "unite65c84df9aed2e";
            var storePassword = "unite65c84df9aed2e@ssl";
            var isSandboxMood = true;

            SSLCommerzGatewayProcessor sslcz = new SSLCommerzGatewayProcessor(storeId, storePassword, isSandboxMood);

            string response = sslcz.InitiateTransaction(PostData);

            return Ok(response);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("CheckoutConfirmation")]
        public IActionResult CheckoutConfirmation()
        {
            if (!(!String.IsNullOrEmpty(Request.Form["status"]) && Request.Form["status"] == "VALID"))
            {
                var Result = "There some error while processing your payment. Please try again.";
                return BadRequest(Result);
            }

            string TrxID = Request.Form["tran_id"];
            // AMOUNT and Currency FROM DB FOR THIS TRANSACTION

            FinalMR finalMR = _finalMRService.GetFinalMRByKey(Convert.ToInt64(TrxID)).Result;
            string amount = $"{finalMR.MRNetPremium}";
            string currency = "BDT";

            var storeId = "unite65c84df9aed2e";
            var storePassword = "unite65c84df9aed2e@ssl";

            SSLCommerzGatewayProcessor sslcz = new SSLCommerzGatewayProcessor(storeId, storePassword, true);
            var resonse = sslcz.OrderValidate(TrxID, amount, currency, Request);
            var successInfo = $"Validation Response: {resonse}";

            if (resonse == true)
            {
                finalMR.Pay_Status = true;

                _finalMRService.Update(finalMR);

                //finalMR = _finalMRService.GetFinalMRByKey(Convert.ToInt64(TrxID)).Result;

                if(finalMR.Pay_Status == true)
                {
                    FinalMRReportParam rParam = new FinalMRReportParam();
                    rParam.FinalMRKey = Convert.ToInt32(TrxID);

                    //ReportDocument file =_reportingService.ReportOMP(rParam);

                    ReportDocument file = new ReportDocument();

                    try
                    {
                        if(finalMR.Class_Name.Trim().ToLower() == "miscellaneous" 
                            && finalMR.Sub_Class_Name.Trim().ToLower() == "overseas mediclaim")
                        {
                            file = _reportingService.ReportOMP(rParam);
                        }
                        else if (finalMR.Class_Name.Trim().ToLower() == "motor"
                            && finalMR.Sub_Class_Name.Trim().ToLower() == "certificate")
                        {
                            file = _reportingService.ReportMotor(rParam);
                        }

                        //if (file.FilePath.IsNullOrEmpty())
                        //{
                        //    return NotFound();
                        //}
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    var baseUrl = Request.Scheme + "://" + Request.Host;
                    return Redirect(baseUrl + "/ReportsDownload/" + file.FileName);

                }
            }
            
            return Ok(successInfo);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CheckoutFail")]
        public IActionResult CheckoutFail()
        {
            var Result = "There some error while processing your payment. Please try again.";
            return Ok(Result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CheckoutCancel")]
        public IActionResult CheckoutCancel()
        {
            var Result = "Your payment has been cancel";
            return Ok(Result);
        }


    }
}
