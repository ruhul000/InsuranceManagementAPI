using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace InsuranceManagementAPI.Data.Repository
{
    public class FinalMRRepository : IFinalMRRepository
    {
        private readonly PolicyDBContext _context;

        public FinalMRRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<long> Add(FinalMRDto finalMRDto)
        {


            long MrKey = 0;
            try
            {
                var paramList = new List<SqlParameter>();

                paramList.Add(new SqlParameter { ParameterName = "@FinalMRKey", SqlDbType = System.Data.SqlDbType.BigInt, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@FinalMRKeyREF", Value = finalMRDto.FinalMRKeyREF });
                paramList.Add(new SqlParameter { ParameterName = "@BranchKey", Value = finalMRDto.BranchKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Class_Name", Value = finalMRDto.Class_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Sub_Class_Name", Value = finalMRDto.Sub_Class_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@YearName", Value = finalMRDto.YearName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType", Value = finalMRDto.MRType.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_2", Value = finalMRDto.MRType_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_3", Value = finalMRDto.MRType_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_4", Value = finalMRDto.MRType_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRCode", Value = finalMRDto.MRCode.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRCode_Dis", Value = finalMRDto.MRCode_Dis.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRDate", Value = finalMRDto.MRDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCode", Value = finalMRDto.DocCode.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocNo", Value = finalMRDto.DocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocDate", Value = finalMRDto.DocDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoverNoteNo", Value = finalMRDto.CoverNoteNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CNDate", Value = finalMRDto.CNDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PolicyNo", Value = finalMRDto.PolicyNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PODate", Value = finalMRDto.PODate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoIns", Value = finalMRDto.CoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ComKeyCoIns", Value = finalMRDto.ComKeyCoIns.ToDBNullIfNothing() });

                paramList.Add(new SqlParameter { ParameterName = "@LeaderDocNo", Value = finalMRDto.LeaderDocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsPer", Value = finalMRDto.CoInsPer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@We_Leader", Value = finalMRDto.We_Leader.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@SumInsured", Value = finalMRDto.SumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@SumInsuredCoIns", Value = finalMRDto.SumInsuredCoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRNetPremium", Value = finalMRDto.MRNetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@NetPremium", Value = finalMRDto.NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VatPer", Value = finalMRDto.VatPer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VatAmount", Value = finalMRDto.VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@StampDuty", Value = finalMRDto.StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@OthersAmount", Value = finalMRDto.OthersAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_SumInsured", Value = finalMRDto.Ref_SumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_SumInsuredCoIns", Value = finalMRDto.Ref_SumInsuredCoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_NetPremium", Value = finalMRDto.Ref_NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_VatAmount", Value = finalMRDto.Ref_VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_StampDuty", Value = finalMRDto.Ref_StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_ChargeAmount", Value = finalMRDto.Ref_ChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_DocNo", Value = finalMRDto.Ref_DocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_CoInsSumInsured", Value = finalMRDto.Ref_CoInsSumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_CoInsNetPremium", Value = finalMRDto.Ref_CoInsNetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Active", Value = finalMRDto.Active.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DepositDate", Value = finalMRDto.DepositDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_NetPremium", Value = finalMRDto.Depo_NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_NetPremium_CoIns", Value = finalMRDto.Depo_NetPremium_CoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_VatAmount", Value = finalMRDto.Depo_VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_StampDuty", Value = finalMRDto.Depo_StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MR_Allowable", Value = finalMRDto.MR_Allowable.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Business", Value = finalMRDto.Business.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClientKey", Value = finalMRDto.ClientKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankKey", Value = finalMRDto.BankKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClientKey_Old", Value = finalMRDto.ClientKey_Old.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankKey_Old", Value = finalMRDto.BankKey_Old.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKey", Value = finalMRDto.EmpKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@AgentKey", Value = finalMRDto.AgentKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PeriodFrom", Value = finalMRDto.PeriodFrom.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PeriodTo", Value = finalMRDto.PeriodTo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_1", Value = finalMRDto.Text_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_2", Value = finalMRDto.Text_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_3", Value = finalMRDto.Text_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_4", Value = finalMRDto.Text_Field_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_5", Value = finalMRDto.Text_Field_5.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_6", Value = finalMRDto.Text_Field_6.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_7", Value = finalMRDto.Text_Field_7.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_8", Value = finalMRDto.Text_Field_8.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_9", Value = finalMRDto.Text_Field_9.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_10", Value = finalMRDto.Text_Field_10.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_11", Value = finalMRDto.Text_Field_11.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_12", Value = finalMRDto.Text_Field_12.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_13", Value = finalMRDto.Text_Field_13.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_14", Value = finalMRDto.Text_Field_14.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_15", Value = finalMRDto.Text_Field_15.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_16", Value = finalMRDto.Text_Field_16.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_17", Value = finalMRDto.Text_Field_17.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_18", Value = finalMRDto.Text_Field_18.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_19", Value = finalMRDto.Text_Field_19.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_20", Value = finalMRDto.Text_Field_20.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_21", Value = finalMRDto.Text_Field_21.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_22", Value = finalMRDto.Text_Field_22.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_23", Value = finalMRDto.Text_Field_23.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_24", Value = finalMRDto.Text_Field_24.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_25", Value = finalMRDto.Text_Field_25.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_26", Value = finalMRDto.Text_Field_26.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_27", Value = finalMRDto.Text_Field_27.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_28", Value = finalMRDto.Text_Field_28.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_29", Value = finalMRDto.Text_Field_29.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_30", Value = finalMRDto.Text_Field_30.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_1", Value = finalMRDto.Num_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_2", Value = finalMRDto.Num_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_3", Value = finalMRDto.Num_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_4", Value = finalMRDto.Num_Field_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_5", Value = finalMRDto.Num_Field_5.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_6", Value = finalMRDto.Num_Field_6.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_7", Value = finalMRDto.Num_Field_7.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_8", Value = finalMRDto.Num_Field_8.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_9", Value = finalMRDto.Num_Field_9.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_10", Value = finalMRDto.Num_Field_10.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_11", Value = finalMRDto.Num_Field_11.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_12", Value = finalMRDto.Num_Field_12.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_13", Value = finalMRDto.Num_Field_13.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_14", Value = finalMRDto.Num_Field_14.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_15", Value = finalMRDto.Num_Field_15.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_16", Value = finalMRDto.Num_Field_16.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_17", Value = finalMRDto.Num_Field_17.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_18", Value = finalMRDto.Num_Field_18.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_19", Value = finalMRDto.Num_Field_19.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_20", Value = finalMRDto.Num_Field_20.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_21", Value = finalMRDto.Num_Field_21.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_22", Value = finalMRDto.Num_Field_22.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_23", Value = finalMRDto.Num_Field_23.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_24", Value = finalMRDto.Num_Field_24.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_25", Value = finalMRDto.Num_Field_25.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_26", Value = finalMRDto.Num_Field_26.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_27", Value = finalMRDto.Num_Field_27.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_28", Value = finalMRDto.Num_Field_28.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_29", Value = finalMRDto.Num_Field_29.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_30", Value = finalMRDto.Num_Field_30.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_1", Value = finalMRDto.Date_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_2", Value = finalMRDto.Date_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_3", Value = finalMRDto.Date_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Bank_Guarantee", Value = finalMRDto.Bank_Guarantee.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Coll_Our_Share", Value = finalMRDto.Coll_Our_Share.ToDBNullIfNothing() });

                paramList.Add(new SqlParameter { ParameterName = "@NewClient", Value = finalMRDto.NewClient.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@WithChargeAmount", Value = finalMRDto.WithChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCancel", Value = finalMRDto.DocCancel.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCancelDate", Value = finalMRDto.DocCancelDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@NotUtilized", Value = finalMRDto.NotUtilized.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocEdit", Value = finalMRDto.DocEdit.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ReinsuranceAmount", Value = finalMRDto.ReinsuranceAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClaimAmount", Value = finalMRDto.ClaimAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VoucherKey", Value = finalMRDto.VoucherKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@HO", Value = finalMRDto.HO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Pay_Status", Value = finalMRDto.Pay_Status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BoughKey", Value = finalMRDto.BoughKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@TargetKey", Value = finalMRDto.TargetKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Remarks", Value = finalMRDto.Remarks.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PaymentType", Value = finalMRDto.PaymentType.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CurrencyName", Value = finalMRDto.CurrencyName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@FCurrText", Value = finalMRDto.FCurrText.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@AmountInWord", Value = finalMRDto.AmountInWord.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankName", Value = finalMRDto.BankName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = finalMRDto.BranchName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChequeNo", Value = finalMRDto.ChequeNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChequeDate", Value = finalMRDto.ChequeDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChargeAmount", Value = finalMRDto.ChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus", Value = finalMRDto.PrintStatus.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus_CN", Value = finalMRDto.PrintStatus_CN.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus_PO", Value = finalMRDto.PrintStatus_PO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Transfer", Value = finalMRDto.Transfer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VATStop", Value = finalMRDto.VATStop.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKeyOld", Value = finalMRDto.EmpKeyOld.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BlockPIN", Value = finalMRDto.BlockPIN.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsBillRec", Value = finalMRDto.CoInsBillRec.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsBillDetails", Value = finalMRDto.CoInsBillDetails.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@LockData", Value = finalMRDto.LockData.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@LockData_Yearly", Value = finalMRDto.LockData_Yearly.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DelFlag", Value = finalMRDto.DelFlag.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PC_Name", Value = finalMRDto.PC_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EUser", Value = finalMRDto.EUser.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@UUser", Value = finalMRDto.UUser.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = finalMRDto.BackupType.ToDBNullIfNothing() });



                await _context.Database.ExecuteSqlRawAsync("EXECUTE Sptab_Final_MR " +
                    "@FinalMRKey OUT,@FinalMRKeyREF,@BranchKey,@Class_Name, @Sub_Class_Name, @YearName, @MRType, @MRType_2, @MRType_3, @MRType_4, " +
                    "@MRCode, @MRCode_Dis, @MRDate, @DocCode, @DocNo, @DocDate, @CoverNoteNo, @CNDate, @PolicyNo, @PODate, @CoIns, @ComKeyCoIns, @LeaderDocNo, " +
                    "@CoInsPer, @We_Leader, @SumInsured,@SumInsuredCoIns, @MRNetPremium, @NetPremium,@VatPer, @VatAmount, @StampDuty,@OthersAmount, @Ref_SumInsured, " +
                    "@Ref_SumInsuredCoIns, @Ref_NetPremium, @Ref_VatAmount, @Ref_StampDuty, @Ref_ChargeAmount, @Ref_DocNo, @Ref_CoInsSumInsured, @Ref_CoInsNetPremium, " +
                    "@Active, @DepositDate, @Depo_NetPremium, @Depo_NetPremium_CoIns, @Depo_VatAmount, @Depo_StampDuty, @MR_Allowable, @Business,@ClientKey, " +
                    "@BankKey, @ClientKey_Old, @BankKey_Old,@EmpKey, @AgentKey, @PeriodFrom, @PeriodTo, @Text_Field_1,@Text_Field_2,@Text_Field_3,@Text_Field_4, " +
                    "@Text_Field_5, @Text_Field_6, @Text_Field_7, @Text_Field_8, @Text_Field_9, @Text_Field_10, @Text_Field_11, @Text_Field_12, @Text_Field_13, " +
                    "@Text_Field_14, @Text_Field_15, @Text_Field_16, @Text_Field_17, @Text_Field_18, @Text_Field_19, @Text_Field_20, @Text_Field_21, @Text_Field_22, " +
                    "@Text_Field_23,@Text_Field_24,@Text_Field_25, @Text_Field_26, @Text_Field_27, @Text_Field_28,@Text_Field_29, @Text_Field_30, " +
                    "@Num_Field_1,@Num_Field_2,@Num_Field_3, @Num_Field_4, @Num_Field_5, @Num_Field_6, @Num_Field_7, @Num_Field_8,@Num_Field_9, @Num_Field_10, " +
                    "@Num_Field_11, @Num_Field_12,@Num_Field_13,@Num_Field_14, @Num_Field_15, @Num_Field_16, @Num_Field_17, @Num_Field_18, @Num_Field_19, @Num_Field_20," +
                    "@Num_Field_21, @Num_Field_22, @Num_Field_23,@Num_Field_24,@Num_Field_25,@Num_Field_26,@Num_Field_27,@Num_Field_28,@Num_Field_29,@Num_Field_30," +
                    "@Date_Field_1,@Date_Field_2,@Date_Field_3, @Bank_Guarantee, @Coll_Our_Share,@NewClient, @WithChargeAmount, @DocCancel, @DocCancelDate, @NotUtilized, " +
                    "@DocEdit, @ReinsuranceAmount, @ClaimAmount, @VoucherKey, @HO, @Pay_Status, @BoughKey, @TargetKey, @Remarks, @PaymentType, @CurrencyName, @FCurrText, " +
                    "@AmountInWord, @BankName, @BranchName, @ChequeNo, @ChequeDate, @ChargeAmount, @PrintStatus, @PrintStatus_CN, @PrintStatus_PO, @Transfer, @VATStop, " +
                    "@EmpKeyOld, @BlockPIN, @CoInsBillRec, @CoInsBillDetails, @LockData, @LockData_Yearly, @DelFlag, @PC_Name, @EUser, @UUser, @BackupType ",
                    paramList);

                MrKey = Convert.ToInt64(paramList[0].Value);

            }
            catch (Exception ex)
            {

            }
            return MrKey;
        }

        public async Task<bool> Update(FinalMRDto finalMRDto)
        {
            bool IsUpdate = false;
            try
            {
                var paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
                paramList.Add(new SqlParameter { ParameterName = "@FinalMRKey", Value = finalMRDto.FinalMRKey });
                paramList.Add(new SqlParameter { ParameterName = "@FinalMRKeyREF", Value = finalMRDto.FinalMRKeyREF });
                paramList.Add(new SqlParameter { ParameterName = "@BranchKey", Value = finalMRDto.BranchKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Class_Name", Value = finalMRDto.Class_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Sub_Class_Name", Value = finalMRDto.Sub_Class_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@YearName", Value = finalMRDto.YearName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType", Value = finalMRDto.MRType.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_2", Value = finalMRDto.MRType_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_3", Value = finalMRDto.MRType_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRType_4", Value = finalMRDto.MRType_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRCode", Value = finalMRDto.MRCode.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRCode_Dis", Value = finalMRDto.MRCode_Dis.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRDate", Value = finalMRDto.MRDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCode", Value = finalMRDto.DocCode.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocNo", Value = finalMRDto.DocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocDate", Value = finalMRDto.DocDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoverNoteNo", Value = finalMRDto.CoverNoteNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CNDate", Value = finalMRDto.CNDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PolicyNo", Value = finalMRDto.PolicyNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PODate", Value = finalMRDto.PODate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoIns", Value = finalMRDto.CoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ComKeyCoIns", Value = finalMRDto.ComKeyCoIns.ToDBNullIfNothing() });

                paramList.Add(new SqlParameter { ParameterName = "@LeaderDocNo", Value = finalMRDto.LeaderDocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsPer", Value = finalMRDto.CoInsPer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@We_Leader", Value = finalMRDto.We_Leader.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@SumInsured", Value = finalMRDto.SumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@SumInsuredCoIns", Value = finalMRDto.SumInsuredCoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MRNetPremium", Value = finalMRDto.MRNetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@NetPremium", Value = finalMRDto.NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VatPer", Value = finalMRDto.VatPer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VatAmount", Value = finalMRDto.VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@StampDuty", Value = finalMRDto.StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@OthersAmount", Value = finalMRDto.OthersAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_SumInsured", Value = finalMRDto.Ref_SumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_SumInsuredCoIns", Value = finalMRDto.Ref_SumInsuredCoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_NetPremium", Value = finalMRDto.Ref_NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_VatAmount", Value = finalMRDto.Ref_VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_StampDuty", Value = finalMRDto.Ref_StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_ChargeAmount", Value = finalMRDto.Ref_ChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_DocNo", Value = finalMRDto.Ref_DocNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_CoInsSumInsured", Value = finalMRDto.Ref_CoInsSumInsured.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Ref_CoInsNetPremium", Value = finalMRDto.Ref_CoInsNetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Active", Value = finalMRDto.Active.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DepositDate", Value = finalMRDto.DepositDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_NetPremium", Value = finalMRDto.Depo_NetPremium.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_NetPremium_CoIns", Value = finalMRDto.Depo_NetPremium_CoIns.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_VatAmount", Value = finalMRDto.Depo_VatAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Depo_StampDuty", Value = finalMRDto.Depo_StampDuty.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@MR_Allowable", Value = finalMRDto.MR_Allowable.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Business", Value = finalMRDto.Business.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClientKey", Value = finalMRDto.ClientKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankKey", Value = finalMRDto.BankKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClientKey_Old", Value = finalMRDto.ClientKey_Old.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankKey_Old", Value = finalMRDto.BankKey_Old.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKey", Value = finalMRDto.EmpKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@AgentKey", Value = finalMRDto.AgentKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PeriodFrom", Value = finalMRDto.PeriodFrom.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PeriodTo", Value = finalMRDto.PeriodTo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_1", Value = finalMRDto.Text_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_2", Value = finalMRDto.Text_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_3", Value = finalMRDto.Text_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_4", Value = finalMRDto.Text_Field_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_5", Value = finalMRDto.Text_Field_5.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_6", Value = finalMRDto.Text_Field_6.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_7", Value = finalMRDto.Text_Field_7.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_8", Value = finalMRDto.Text_Field_8.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_9", Value = finalMRDto.Text_Field_9.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_10", Value = finalMRDto.Text_Field_10.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_11", Value = finalMRDto.Text_Field_11.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_12", Value = finalMRDto.Text_Field_12.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_13", Value = finalMRDto.Text_Field_13.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_14", Value = finalMRDto.Text_Field_14.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_15", Value = finalMRDto.Text_Field_15.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_16", Value = finalMRDto.Text_Field_16.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_17", Value = finalMRDto.Text_Field_17.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_18", Value = finalMRDto.Text_Field_18.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_19", Value = finalMRDto.Text_Field_19.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_20", Value = finalMRDto.Text_Field_20.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_21", Value = finalMRDto.Text_Field_21.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_22", Value = finalMRDto.Text_Field_22.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_23", Value = finalMRDto.Text_Field_23.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_24", Value = finalMRDto.Text_Field_24.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_25", Value = finalMRDto.Text_Field_25.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_26", Value = finalMRDto.Text_Field_26.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_27", Value = finalMRDto.Text_Field_27.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_28", Value = finalMRDto.Text_Field_28.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_29", Value = finalMRDto.Text_Field_29.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Text_Field_30", Value = finalMRDto.Text_Field_30.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_1", Value = finalMRDto.Num_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_2", Value = finalMRDto.Num_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_3", Value = finalMRDto.Num_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_4", Value = finalMRDto.Num_Field_4.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_5", Value = finalMRDto.Num_Field_5.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_6", Value = finalMRDto.Num_Field_6.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_7", Value = finalMRDto.Num_Field_7.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_8", Value = finalMRDto.Num_Field_8.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_9", Value = finalMRDto.Num_Field_9.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_10", Value = finalMRDto.Num_Field_10.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_11", Value = finalMRDto.Num_Field_11.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_12", Value = finalMRDto.Num_Field_12.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_13", Value = finalMRDto.Num_Field_13.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_14", Value = finalMRDto.Num_Field_14.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_15", Value = finalMRDto.Num_Field_15.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_16", Value = finalMRDto.Num_Field_16.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_17", Value = finalMRDto.Num_Field_17.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_18", Value = finalMRDto.Num_Field_18.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_19", Value = finalMRDto.Num_Field_19.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_20", Value = finalMRDto.Num_Field_20.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_21", Value = finalMRDto.Num_Field_21.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_22", Value = finalMRDto.Num_Field_22.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_23", Value = finalMRDto.Num_Field_23.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_24", Value = finalMRDto.Num_Field_24.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_25", Value = finalMRDto.Num_Field_25.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_26", Value = finalMRDto.Num_Field_26.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_27", Value = finalMRDto.Num_Field_27.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_28", Value = finalMRDto.Num_Field_28.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_29", Value = finalMRDto.Num_Field_29.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Num_Field_30", Value = finalMRDto.Num_Field_30.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_1", Value = finalMRDto.Date_Field_1.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_2", Value = finalMRDto.Date_Field_2.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Date_Field_3", Value = finalMRDto.Date_Field_3.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Bank_Guarantee", Value = finalMRDto.Bank_Guarantee.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Coll_Our_Share", Value = finalMRDto.Coll_Our_Share.ToDBNullIfNothing() });

                paramList.Add(new SqlParameter { ParameterName = "@NewClient", Value = finalMRDto.NewClient.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@WithChargeAmount", Value = finalMRDto.WithChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCancel", Value = finalMRDto.DocCancel.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocCancelDate", Value = finalMRDto.DocCancelDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@NotUtilized", Value = finalMRDto.NotUtilized.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DocEdit", Value = finalMRDto.DocEdit.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ReinsuranceAmount", Value = finalMRDto.ReinsuranceAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ClaimAmount", Value = finalMRDto.ClaimAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VoucherKey", Value = finalMRDto.VoucherKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@HO", Value = finalMRDto.HO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Pay_Status", Value = finalMRDto.Pay_Status.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BoughKey", Value = finalMRDto.BoughKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@TargetKey", Value = finalMRDto.TargetKey.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Remarks", Value = finalMRDto.Remarks.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PaymentType", Value = finalMRDto.PaymentType.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CurrencyName", Value = finalMRDto.CurrencyName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@FCurrText", Value = finalMRDto.FCurrText.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@AmountInWord", Value = finalMRDto.AmountInWord.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BankName", Value = finalMRDto.BankName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BranchName", Value = finalMRDto.BranchName.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChequeNo", Value = finalMRDto.ChequeNo.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChequeDate", Value = finalMRDto.ChequeDate.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@ChargeAmount", Value = finalMRDto.ChargeAmount.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus", Value = finalMRDto.PrintStatus.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus_CN", Value = finalMRDto.PrintStatus_CN.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PrintStatus_PO", Value = finalMRDto.PrintStatus_PO.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@Transfer", Value = finalMRDto.Transfer.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@VATStop", Value = finalMRDto.VATStop.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@EmpKeyOld", Value = finalMRDto.EmpKeyOld.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BlockPIN", Value = finalMRDto.BlockPIN.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsBillRec", Value = finalMRDto.CoInsBillRec.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@CoInsBillDetails", Value = finalMRDto.CoInsBillDetails.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@LockData", Value = true });
                paramList.Add(new SqlParameter { ParameterName = "@LockData_Yearly", Value = finalMRDto.LockData_Yearly.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@DelFlag", Value = finalMRDto.DelFlag.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@PC_Name", Value = finalMRDto.PC_Name.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@UUser", Value = finalMRDto.UUser.ToDBNullIfNothing() });
                paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = finalMRDto.BackupType.ToDBNullIfNothing() });



                await _context.Database.ExecuteSqlRawAsync("EXECUTE Sptab_Final_MR_UPDATE " +
                    "@Result OUT,@FinalMRKey, @FinalMRKeyREF,@BranchKey,@Class_Name, @Sub_Class_Name, @YearName, @MRType, @MRType_2, @MRType_3, @MRType_4, " +
                    "@MRCode, @MRCode_Dis, @MRDate, @DocCode, @DocNo, @DocDate, @CoverNoteNo, @CNDate, @PolicyNo, @PODate, @CoIns, @ComKeyCoIns, @LeaderDocNo, " +
                    "@CoInsPer, @We_Leader, @SumInsured,@SumInsuredCoIns, @MRNetPremium, @NetPremium,@VatPer, @VatAmount, @StampDuty,@OthersAmount, @Ref_SumInsured, " +
                    "@Ref_SumInsuredCoIns, @Ref_NetPremium, @Ref_VatAmount, @Ref_StampDuty, @Ref_ChargeAmount, @Ref_DocNo, @Ref_CoInsSumInsured, @Ref_CoInsNetPremium, " +
                    "@Active, @DepositDate, @Depo_NetPremium, @Depo_NetPremium_CoIns, @Depo_VatAmount, @Depo_StampDuty, @MR_Allowable, @Business,@ClientKey, " +
                    "@BankKey, @ClientKey_Old, @BankKey_Old,@EmpKey, @AgentKey, @PeriodFrom, @PeriodTo, @Text_Field_1,@Text_Field_2,@Text_Field_3,@Text_Field_4, " +
                    "@Text_Field_5, @Text_Field_6, @Text_Field_7, @Text_Field_8, @Text_Field_9, @Text_Field_10, @Text_Field_11, @Text_Field_12, @Text_Field_13, " +
                    "@Text_Field_14, @Text_Field_15, @Text_Field_16, @Text_Field_17, @Text_Field_18, @Text_Field_19, @Text_Field_20, @Text_Field_21, @Text_Field_22, " +
                    "@Text_Field_23,@Text_Field_24,@Text_Field_25, @Text_Field_26, @Text_Field_27, @Text_Field_28,@Text_Field_29, @Text_Field_30, " +
                    "@Num_Field_1,@Num_Field_2,@Num_Field_3, @Num_Field_4, @Num_Field_5, @Num_Field_6, @Num_Field_7, @Num_Field_8,@Num_Field_9, @Num_Field_10, " +
                    "@Num_Field_11, @Num_Field_12,@Num_Field_13,@Num_Field_14, @Num_Field_15, @Num_Field_16, @Num_Field_17, @Num_Field_18, @Num_Field_19, @Num_Field_20," +
                    "@Num_Field_21, @Num_Field_22, @Num_Field_23,@Num_Field_24,@Num_Field_25,@Num_Field_26,@Num_Field_27,@Num_Field_28,@Num_Field_29,@Num_Field_30," +
                    "@Date_Field_1,@Date_Field_2,@Date_Field_3, @Bank_Guarantee, @Coll_Our_Share,@NewClient, @WithChargeAmount, @DocCancel, @DocCancelDate, @NotUtilized, " +
                    "@DocEdit, @ReinsuranceAmount, @ClaimAmount, @VoucherKey, @HO, @Pay_Status, @BoughKey, @TargetKey, @Remarks, @PaymentType, @CurrencyName, @FCurrText, " +
                    "@AmountInWord, @BankName, @BranchName, @ChequeNo, @ChequeDate, @ChargeAmount, @PrintStatus, @PrintStatus_CN, @PrintStatus_PO, @Transfer, @VATStop, " +
                    "@EmpKeyOld, @BlockPIN, @CoInsBillRec, @CoInsBillDetails, @LockData, @LockData_Yearly, @DelFlag, @PC_Name, @UUser, @BackupType ",
                    paramList);

                IsUpdate = Convert.ToBoolean(paramList[0].Value);


            }
            catch (Exception ex)
            {

            }
            return IsUpdate;
        }
        public async Task<FinalMRDto> GetFinalMRByID(long FinalMRKey)
        {

            FinalMRDto FinalMR = null;
            try
            {
                FinalMR = await _context.FinalMR.FirstOrDefaultAsync(obj => obj.FinalMRKey == FinalMRKey);
            }
            catch (Exception ex)
            {
            }

            return FinalMR;
        }

        public async Task<FinalMRDto> GetFinalMRByCodeBranchYear(FinalMRDto searchObj)
        {

            FinalMRDto FinalMR = null;
            try
            {
                FinalMR = await _context.FinalMR.FirstOrDefaultAsync(obj => obj.DocCode == searchObj.DocCode && obj.Class_Name == searchObj.Class_Name && obj.Sub_Class_Name == searchObj.Sub_Class_Name && obj.BranchKey == searchObj.BranchKey && obj.YearName == searchObj.YearName);
            }
            catch (Exception ex)
            {
            }

            return FinalMR;
        }

        public async Task<IEnumerable<FinalMRDto>> GetAll()
        {
            return await _context.FinalMR.ToListAsync();
        }


    }
}
