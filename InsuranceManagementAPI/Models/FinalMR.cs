using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementAPI.Models
{
    public class FinalMR
    {
        public Int64 FinalMRKey { get; set; }
        public Int64 FinalMRKeyREF { get; set; }
        public int BranchKey { get; set; }
        public string? Class_Name { get; set; }
        public string? Sub_Class_Name { get; set; }
        public Int16 YearName { get; set; }
        public string? MRType { get; set; }
        public string? MRType_2 { get; set; }
        public string? MRType_3 { get; set; }
        public string? MRType_4 { get; set; }
        public int? MRCode { get; set; }
        public string? MRCode_Dis { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? MRDate { get; set; }
        public int DocCode { get; set; }
        public string? DocNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DocDate { get; set; }
        public string? CoverNoteNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CNDate { get; set; }
        public string? PolicyNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PODate { get; set; }
        public bool CoIns { get; set; }
        public int ComKeyCoIns { get; set; }
        public string? LeaderDocNo { get; set; }
        public decimal? CoInsPer { get; set; }
        public bool We_Leader { get; set; }
        public decimal? SumInsured { get; set; }
        public decimal? SumInsuredCoIns { get; set; }
        public decimal? MRNetPremium { get; set; }
        public decimal? NetPremium { get; set; }
        public decimal? VatPer { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? StampDuty { get; set; }
        public decimal? OthersAmount { get; set; }
        public decimal? Ref_SumInsured { get; set; }
        public decimal? Ref_SumInsuredCoIns { get; set; }
        public decimal? Ref_NetPremium { get; set; }
        public decimal? Ref_VatAmount { get; set; }
        public decimal? Ref_StampDuty { get; set; }
        public decimal? Ref_ChargeAmount { get; set; }
        public string? Ref_DocNo { get; set; }
        public decimal? Ref_CoInsSumInsured { get; set; }
        public decimal? Ref_CoInsNetPremium { get; set; }
        public bool Active { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DepositDate { get; set; }
        public decimal? Depo_NetPremium { get; set; }
        public decimal? Depo_NetPremium_CoIns { get; set; }
        public decimal? Depo_VatAmount { get; set; }
        public decimal? Depo_StampDuty { get; set; }
        public int? MR_Allowable { get; set; }
        public int? Business { get; set; }
        public Int64? ClientKey { get; set; }
        public Int64? BankKey { get; set; }
        public Int64? ClientKey_Old { get; set; }
        public Int64? BankKey_Old { get; set; }
        public int? EmpKey { get; set; }
        public int? AgentKey { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodFrom { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodTo { get; set; }
        public string? Text_Field_1 { get; set; }
        public string? Text_Field_2 { get; set; }
        public string? Text_Field_3 { get; set; }
        public string? Text_Field_4 { get; set; }
        public string? Text_Field_5 { get; set; }
        public string? Text_Field_6 { get; set; }
        public string? Text_Field_7 { get; set; }
        public string? Text_Field_8 { get; set; }
        public string? Text_Field_9 { get; set; }
        public string? Text_Field_10 { get; set; }
        public string? Text_Field_11 { get; set; }
        public string? Text_Field_12 { get; set; }
        public string? Text_Field_13 { get; set; }
        public string? Text_Field_14 { get; set; }
        public string? Text_Field_15 { get; set; }
        public string? Text_Field_16 { get; set; }
        public string? Text_Field_17 { get; set; }
        public string? Text_Field_18 { get; set; }
        public string? Text_Field_19 { get; set; }
        public string? Text_Field_20 { get; set; }
        public string? Text_Field_21 { get; set; }
        public string? Text_Field_22 { get; set; }
        public string? Text_Field_23 { get; set; }
        public string? Text_Field_24 { get; set; }
        public string? Text_Field_25 { get; set; }
        public string? Text_Field_26 { get; set; }
        public string? Text_Field_27 { get; set; }
        public string? Text_Field_28 { get; set; }
        public string? Text_Field_29 { get; set; }
        public string? Text_Field_30 { get; set; }
        public decimal? Num_Field_1 { get; set; }
        public decimal? Num_Field_2 { get; set; }
        public decimal? Num_Field_3 { get; set; }
        public decimal? Num_Field_4 { get; set; }
        public decimal? Num_Field_5 { get; set; }
        public decimal? Num_Field_6 { get; set; }
        public decimal? Num_Field_7 { get; set; }
        public decimal? Num_Field_8 { get; set; }
        public decimal? Num_Field_9 { get; set; }
        public decimal? Num_Field_10 { get; set; }
        public decimal? Num_Field_11 { get; set; }
        public decimal? Num_Field_12 { get; set; }
        public decimal? Num_Field_13 { get; set; }
        public decimal? Num_Field_14 { get; set; }
        public decimal? Num_Field_15 { get; set; }
        public decimal? Num_Field_16 { get; set; }
        public decimal? Num_Field_17 { get; set; }
        public decimal? Num_Field_18 { get; set; }
        public decimal? Num_Field_19 { get; set; }
        public decimal? Num_Field_20 { get; set; }
        public decimal? Num_Field_21 { get; set; }
        public decimal? Num_Field_22 { get; set; }
        public decimal? Num_Field_23 { get; set; }
        public decimal? Num_Field_24 { get; set; }
        public decimal? Num_Field_25 { get; set; }
        public decimal? Num_Field_26 { get; set; }
        public decimal? Num_Field_27 { get; set; }
        public decimal? Num_Field_28 { get; set; }
        public decimal? Num_Field_29 { get; set; }
        public decimal? Num_Field_30 { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Field_1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Field_2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Field_3 { get; set; }
        public int? Bank_Guarantee { get; set; }
        public string? Coll_Our_Share { get; set; }
        public int? NewClient { get; set; }
        public int? WithChargeAmount { get; set; }
        public bool DocCancel { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DocCancelDate { get; set; }
        public bool NotUtilized { get; set; }
        public bool DocEdit { get; set; }
        public decimal? ReinsuranceAmount { get; set; }
        public decimal? ClaimAmount { get; set; }
        public Int64? VoucherKey { get; set; }
        public bool HO { get; set; }
        public bool Pay_Status { get; set; }
        public int? BoughKey { get; set; }
        public decimal? TargetKey { get; set; }
        public string? Remarks { get; set; }
        public string? PaymentType { get; set; }
        public string? CurrencyName { get; set; }
        public string? FCurrText { get; set; }
        public string? AmountInWord { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? ChequeNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ChequeDate { get; set; }
        public decimal? ChargeAmount { get; set; }
        public bool? PrintStatus { get; set; }
        public bool? PrintStatus_CN { get; set; }
        public bool? PrintStatus_PO { get; set; }
        public int? Transfer { get; set; }
        public bool? VATStop { get; set; }
        public int? EmpKeyOld { get; set; }
        public bool BlockPIN { get; set; }
        public bool CoInsBillRec { get; set; }
        public string? CoInsBillDetails { get; set; }
        public bool LockData { get; set; }
        public bool LockData_Yearly { get; set; }
        public bool DelFlag { get; set; }
        public string? PC_Name { get; set; }
        public int EUser { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EDate { get; set; }
        public int UUser { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UDate { get; set; }
        public bool BackupType { get; set; }

    }
}
