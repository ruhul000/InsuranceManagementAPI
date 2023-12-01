﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("CurrencyInfo")]
    public class CurrencyDto
    {
        [Key]
        public int CurrencyKey { get; set; }
        public string? CurrencyName { get; set; }
        public decimal Coll { get; set; }
        public decimal BankRate{ get; set;}
        public bool BackupType { get; set;}
    }
}
