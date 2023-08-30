using AutoMapper;
using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Models.Map
{
    public class PolicyMapper : Profile
    {
        public PolicyMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserDto, UserResponse>().ReverseMap();
            CreateMap<BankDto, Bank>().ReverseMap();
            CreateMap<BankBranchDto, BankBranch>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
        }
    }
}
