using AutoMapper;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.API.Responses.Cities;
using Jalasoft.Interns.API.Responses.Employees;
using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.API.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<PostEmpoyeeRequest, Employee>()
                .ReverseMap();

            CreateMap<Employee, PostEmployeeResponse>()
                .ReverseMap();

            CreateMap<Employee, PatchEmployee>()
                .ReverseMap();

            CreateMap<PatchEmployee, Employee>()
                .ReverseMap();

            CreateMap<CreateHospitalRequestDto, Hospital>();
            CreateMap<Hospital, HospitalResponseDto>();
        }
    }
}
