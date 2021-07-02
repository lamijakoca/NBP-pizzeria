using AutoMapper;
using backend.DTO;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Profiles
{
    public class PizzaActualProfile : Profile
    {
        public PizzaActualProfile()
        {
            CreateMap<PizzaActual, PizzaActualDTO>().ReverseMap();
        }
    }
}
