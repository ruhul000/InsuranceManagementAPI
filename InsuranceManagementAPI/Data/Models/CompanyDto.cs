﻿namespace InsuranceManagementAPI.Data.Models
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string IssuingPlace { get; set; }
        public string Web { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Banner { get; set; }
    }
}
