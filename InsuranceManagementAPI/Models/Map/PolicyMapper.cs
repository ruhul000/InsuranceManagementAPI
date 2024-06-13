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
            CreateMap<InsurancebranchDto,InsuranceCompany>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<BranchDto, Branch>().ReverseMap();
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<DesignationDto, Designation>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<AgentDto, Agent>().ReverseMap();
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            CreateMap<MarineCargoTariffDto, MarineCargoTariff>().ReverseMap();
            CreateMap<FinalMRDto, FinalMR>().ReverseMap();
            CreateMap<MediclaimTariffDto, MediclaimTariff>().ReverseMap();
            CreateMap<BankPaymentDto, BankPayment>().ReverseMap();
            CreateMap<MotorTariffDto, MotorTariff>().ReverseMap();

        }
    }
}
