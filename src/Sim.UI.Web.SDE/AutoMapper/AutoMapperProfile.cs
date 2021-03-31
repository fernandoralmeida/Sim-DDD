﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Sim.UI.Web.SDE.AutoMapper
{    
    using ViewModels;
    using Sim.Domain.SDE.Entities; 
    
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
        {
            CreateMap<Pessoa, VMPessoa>();
            CreateMap<VMPessoa, Pessoa>().ReverseMap();

            CreateMap<Empresa, VMEmpresa>();
            CreateMap<VMEmpresa, Empresa>().ReverseMap();

            CreateMap<Empresa_QSA, VMEmpresaQsa>();
            CreateMap<VMEmpresaQsa, Empresa_QSA>().ReverseMap();
        }
    }
}

