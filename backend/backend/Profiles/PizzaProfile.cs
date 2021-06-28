using AutoMapper;
using backend.DTO;
using backend.Models;

namespace backend.Profiles
{
    public class PizzaProfile : Profile
    {
       public PizzaProfile()
        {
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
        }
    }
}
