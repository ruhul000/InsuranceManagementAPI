using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services.PaymentGateway;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace InsuranceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSLPaymentController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            var productName = "HP Pavilion Series Laptop";
            var price = 85000;

            var baseUrl = Request.Scheme + "://" + Request.Host;

            // CREATING LIST OF POST DATA
            NameValueCollection PostData = new NameValueCollection();

            PostData.Add("total_amount", $"{price}");
            PostData.Add("tran_id", "TESTASPNET1234");
            PostData.Add("success_url", baseUrl + "/api/SSLPayment/CheckoutConfirmation");
            PostData.Add("fail_url", baseUrl + "/api/SSLPayment/CheckoutFail");
            PostData.Add("cancel_url", baseUrl + "/api/SSLPayment/CheckoutCancel");

            PostData.Add("version", "3.00");
            PostData.Add("cus_name", "ABC XY");
            PostData.Add("cus_email", "abc.xyz@mail.co");
            PostData.Add("cus_add1", "Address Line On");
            PostData.Add("cus_add2", "Address Line Tw");
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
            var storeId = "sales65cf73323b2a8";
            var storePassword = "sales65cf73323b2a8@ssl";
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
            string amount = "85000";
            string currency = "BDT";

            var storeId = "rejgsggsgsgsgsgeabc28c1c8";
            var storePassword = "rfgsgejagsggsgsgsgsg8c1c8@ssl";

            SSLCommerzGatewayProcessor sslcz = new SSLCommerzGatewayProcessor(storeId, storePassword, true);
            var resonse = sslcz.OrderValidate(TrxID, amount, currency, Request);
            var successInfo = $"Validation Response: {resonse}";

            return Ok(successInfo);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("CheckoutFail")]
        public IActionResult CheckoutFail()
        {
            var Result = "There some error while processing your payment. Please try again.";
            return BadRequest(Result);
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
