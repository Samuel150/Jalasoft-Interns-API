using AutoMapper;
using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.API.Responses.Books;
using Jalasoft.Interns.API.Responses.Employees;
using Jalasoft.Interns.Service.Domain.Books;
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

            CreateMap<PostBookRequest, Book>().ReverseMap();
            CreateMap<Book, PostBookRequest>().ReverseMap();
            CreateMap<PutBookRequest, Book>().ReverseMap();
            CreateMap<PatchBook,  Book>().ReverseMap();
            CreateMap<Book, PostBookResponse>().ReverseMap();
        }
    }
}
