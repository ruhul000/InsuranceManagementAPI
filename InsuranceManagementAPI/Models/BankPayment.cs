namespace InsuranceManagementAPI.Models
{
    public class BankPayment
    {
        public string Reference { get; set; }
        public decimal Amount { get; set; }

        public Int64 FinalMRKey
        {
            get
            {
                return Convert.ToInt64(Reference.Substring(4));
            }

        }
    }
}
