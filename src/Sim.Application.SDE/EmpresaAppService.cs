using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE
{
    using Sim.Domain.SDE.Entities;
    using Interface;
    using Sim.Domain.SDE.Interfaces.Services;

    public class EmpresaAppService : AppServiceBase<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaService _empresaAppService;

        public EmpresaAppService(IEmpresaService empresaAppService)
            :base(empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        public IEnumerable<Empresa> ConsultaByCNAE(string cnae)
        {
            return _empresaAppService.ConsultaByCNAE(cnae);
        }

        public IEnumerable<Empresa> ConsultaByCNPJ(string cnpj)
        {
            return _empresaAppService.ConsultaByCNPJ(cnpj);
        }

        public IEnumerable<Empresa> ConsultaByRazaoSocial(string name)
        {
            return _empresaAppService.ConsultaByRazaoSocial(name);
        }
    }
}
