using Application.Commands;
using Application.Responses;
using AutoMapper;
using Core.Entites;

namespace Application.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponse>()
            .ForMember(dest => dest.DepartmentName,
                       opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : string.Empty));

            CreateMap<CreateEmployeeCommand, Employee>();
        }
    }
}
