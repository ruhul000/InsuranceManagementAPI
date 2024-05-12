using Microsoft.AspNetCore.Authentication;

namespace InsuranceManagementAPI.Models
{
    public class MediclaimTariff
    {
        public int OTIDKey { get; set; }
        public int Days_From{ get; set; }
        public int Days_To { get; set; }
        public int Age_From { get; set; }
        public int Age_To { get;set; }
        public decimal Rate { get; set; }
        public String? PlanType { get; set;}
        public int Tariff_Type { get; set;}
        public int Travel_Type { get; set;}
    }
}
