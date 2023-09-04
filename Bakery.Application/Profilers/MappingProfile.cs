using AutoMapper;
using Bakery.Application.Dtos.BakeryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Profilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BakeryDto, Domain.Entities.Bakery>().ReverseMap();
        }
    }
}
