using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementAPI.Models
{
    public class Designation
    {
        public int DegKey { get; set; }
        public String Deg_Name{ get; set;}
        public String? ShortDeg { get; set;}        
        public String? GradeName { get; set;}
        public String? Salary_Scale { get; set;}
        public int? OrderKey { get; set; }
       
    }
}
