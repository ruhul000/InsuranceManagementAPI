namespace InsuranceManagementAPI.Data.Models
{
    public class BankPaymentDto
    {
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public Int64 FinalMRKey
        {
            get
            {
                return Convert.ToInt64(this.Reference.Substring(4));
            }
        }
    }
}
