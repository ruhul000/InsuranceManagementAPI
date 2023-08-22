using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Data.Models
{
    [Table("tab_Client")]
    public class ClientDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientKey { get; set; }
        public int BranchKey { get; set; }
        public string? ClientName { get; set; }
        public string? ClientNameExtar { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientMobile { get; set; }
        public string? ClientType { get; set; }
        public string? ClientTypeTwo { get; set; }
        public string? ClientSector { get; set; }
        public string? ClientVATNo { get; set; }
        public string? ClientBINNo { get; set; }
        public string? ClientTINNo { get; set; }
        public int? Client_VAT_Exemption { get; set; }
        public int? GroupKey { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientFax { get; set; }
        public string? ClientEMail { get; set; }
        public string? ClientRelation { get; set; }
        public string? ClientWeb { get; set; }
        public string? ClientContractPer { get; set; }
        public string? ClientDesignation { get; set; }
        public decimal? SpecDiscount { get; set; }
        public int? EmpKeyDirectorRef { get; set; }
        public bool? Status { get; set; }
        public decimal? Int_A { get; set; }
        public decimal? Int_B { get; set; }
        public decimal? Int_C { get; set; }
        public decimal? Int_D { get; set; }
        public string? Str_A { get; set; }
        public string? Str_B { get; set; }
        public string? Str_C { get; set; }
        public string? Str_D { get; set; }
        public DateTime? Date_A { get; set; }
        public DateTime? Date_B { get; set; }
        public DateTime? Date_C { get; set; }
        public bool? BackupType { get; set; }
    }
}
