using AutoMapper;
using backend.DTO;
using backend.Models;

namespace backend.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, AddEmployeeDTO>().ReverseMap();
        }
    }
}
