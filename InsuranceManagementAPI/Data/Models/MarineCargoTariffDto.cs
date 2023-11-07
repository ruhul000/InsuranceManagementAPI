using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("Marine_Cargo_Tariff")]

    [Keyless]
    public class MarineCargoTariffDto
    {
        [Ignore]
        public int? TariffKey { get; set; }
        public string? Tariff_Catagory { get; set; }
        [Ignore]
        public string? TypeOfRisk { get; set; }
        [Ignore]
        public string? ItemName { get; set; }
        [Ignore]
        public string? TypeA { get; set; }
        [Ignore]        
        public string? TypeB { get; set; }
        [Ignore]
        public string? TypeC { get; set; }
        [Ignore]
        public decimal? Per { get; set; }
    }
}
