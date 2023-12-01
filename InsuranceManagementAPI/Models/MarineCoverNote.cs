namespace InsuranceManagementAPI.Models
{
    public class MarineCoverNote
    {
        public int YearName { get; set; }
        public int BranchKey { get; set; }
        public Int64 MCCNKey { get; set; }
        public int MCCNCode { get; set; }
        public String? CoverNoteNo { get; set; }
        public bool? CNOpen { get; set; }
        public float? CarryLimit_Ship { get; set;}
        public float? CarryLimit_Air { get; set; }
        public float? CarryLimit_Lorry { get; set; }
        public float? CarryLimit_Train { get; set; }
        public DateTime? CNDate { get; set; }
        public int ClientKey { get; set; }
        public int BankKey { get; set; }
        public String? Interest_Covered { get; set; }
        public String? VoyageForm { get; set; }
        public String? VoyageTo { get;set; }
        public bool CoInsurance { get; set; }
        public float? CoInsurance_Per { get; set; }
        public bool Leader { get; set; }
        public int OtherLeader { get; set; }
        public String? OtherLeader_DocNo { get;set; }
        public String? VoyageVia { get; set; }
        public String? In_Transit_By { get; set; }
        public DateTime? PeriodForm { get; set; }
        public DateTime? PeriodTo { get;set; }
        public float? PeriodFrom { get; set;}
        public float? AmountInsuredExtra { get; set; }
        public String? CurrencySname { get; set; }
        public float? BankRate { get; set;}
        public float? SumInsured { get; set; }
        public int EmpKey { get; set;}
        public string? WarCName { get; set; }
        public float? Marine { get; set; }
        public float? MarinePer { get;set; }
        public float? War { get;set; }
        public float? WarPer { get; set; }
        public bool ChWar { get; set; }
        public float? NetPremium { get; set; }
        public float? VatAmount { get; set; }
        public float? VatPer { get; set; }
        public float? StampDuty { get;set; }
        public float? TotalPremiumFinal { get;set; }
        public String? TariffCatagory { get; set; }
        public String? TypeOfRisk { get; set; }
        public float? Discount { get; set; } 
        public float? SP_Discount { get; set; }
        public String? GenRiskCovered { get; set; }
        public float? PremiumPer { get; set; }
        public String? Itemname { get; set; }
        public float? ND { get; set; }
        public bool? ChND { get; set; }
        public float? TP { get; set; }
        public bool? ChTP { get; set;}
        public float? RFWD { get; set; }
        public bool ChRFWD { get; set; }
        public float? Hooks { get; set; }




    }
}
