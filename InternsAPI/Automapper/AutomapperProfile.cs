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

            CreateMap<CreateHospitalRequestDto, Hospital>().ReverseMap();
            CreateMap<Hospital, HospitalResponseDto>().ReverseMap();
            CreateMap<UpdateHospitalRequestDto, Hospital>().ReverseMap();
            CreateMap<UpdateCityRequestDto, City>().ReverseMap();
            CreateMap<City, CityResponseDto>().ReverseMap();
            CreateMap<CreateCityRequestDto, City>().ReverseMap();
        }
    }
}
