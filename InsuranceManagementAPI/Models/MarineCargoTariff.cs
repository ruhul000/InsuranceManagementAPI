using Microsoft.AspNetCore.Authentication;

namespace InsuranceManagementAPI.Models
{
    public class MarineCargoTariff
    {
        public int? TariffKey { get; set; }
        public string? Tariff_Catagory { get; set; }
        public string? TypeOfRisk { get; set; }
        public string? ItemName { get; set; }
        public string? TypeA { get; set;}
        public string? TypeB { get; set;}
        public string? TypeC { get; set;}
        public decimal? Per { get; set;}
    }
}
