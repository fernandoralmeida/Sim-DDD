using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Sim.Web.SecDE.AutoMapper
{
    using Models;
    using Sim.Domain.SDE.Entities;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pessoa, VM_Pessoa>();
            CreateMap<VM_Pessoa, Pessoa>().ReverseMap();
        }
    }
}
