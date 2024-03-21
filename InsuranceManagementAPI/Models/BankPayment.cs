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
                if(Reference.Length == 17)
                {
                    return Convert.ToInt64(Reference.Substring(4));
                }
                else
                {
                    return 0;
                }
                
            }

        }
    }
}
