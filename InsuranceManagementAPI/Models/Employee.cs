namespace InsuranceManagementAPI.Models
{
    public class Employee
    {
        public int EmpKey { get; set; }
        public String? EmpID { get; set; }
        public int EmpCode { get; set; }
        public int EmpKey_Group { get; set; }
        public int BranchKey { get; set; }
        public Boolean BranchIncharge { get; set; }
        public String? Title { get; set; }
        public String? EmpName { get; set; }
        public String? EmpSurName { get; set; }
        public String? EmpShortName { get; set; }
        public int? DepKey { get; set; }
        public Boolean? DepIncharge { get; set; }
        public int? DegKey { get; set; }
        public String? EmpType { get; set; }
        public String? EmpSex { get; set; }
        public Boolean Director { get; set; }
        public Boolean JobContinue { get; set; }
        public DateTime? DOJ { get; set; }
        public DateTime? DOC { get; set; }//date of confirmation
        public DateTime? DOB { get; set; }
        public String? AGE { get; set; }
        public DateTime? Resign_Date { get; set; }
        public DateTime? Release_Date { get; set; }
        public DateTime? Retirement_Date { get; set; }
        public String? Father_Name { get; set; }
        public String? Mother_Name { get; set; }
        public String? Spouse_Name { get; set; }
        public String? Nominee { get; set; }
        public String? Merital_Status { get; set; }
        public DateTime? Marriage_Date { get; set; }
        public String? Religion { get; set; }
        public String? Nationality { get; set; }
        public String? National_ID_No { get; set; }
        public String? Passport_No { get; set; }
        public String? TIN_No { get; set; }
        public String? Blood_Group { get; set; }
        public String? PresentAddress { get; set; }
        public String? PermanentAddress { get; set; }
        public string? Native_Land { get; set; }
        public String? Home_District { get; set; }
        public String? Phone { get; set; }
        public String? Mobile { get; set; }
        public String? Email { get; set; }        
        public String? Emp_Image { get; set; }
        public Boolean? Active { get; set; }
        public DateTime? LastPromotion_Date { get; set; }
        public DateTime? LastIncrement_Date { get; set; }
        public DateTime? PF_Join_Date { get; set; }
        public Boolean? Extended { get; set; }
        public DateTime? ExtendedDate { get; set; }
        public int? Probation_Period { get; set; }
        public DateTime? Probation_Date { get; set; }
        public String? Mobile_Set_Name { get; set; }
        public Decimal? Mobile_Bill_Amount { get; set; }
        public Decimal? Car_Fuel_Amount { get; set; }
        public Decimal? Car_Maintains_Amount { get; set; }
        public Decimal? Other_Maintains_Amount { get; set; }
        public string? Facility_Remarks { get; set; }
        public DateTime? Contract_Date { get; set; }
        public string? Remarks { get; set; }



    }
}
