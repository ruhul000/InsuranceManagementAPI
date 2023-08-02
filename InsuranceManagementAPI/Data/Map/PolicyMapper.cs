using AutoMapper;
using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Data.Map
{
    public class PolicyMapper : Profile
    {
        public PolicyMapper()
        {
            CreateMap<BankDto, Bank>().ReverseMap();
        }
    }
}
