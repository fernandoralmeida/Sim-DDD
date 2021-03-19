using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Services.SDE
{
    using Sim.Domain.SDE.Entities;
    using Sim.Domain.SDE.Interfaces.Services;
    using Sim.Domain.SDE.Interfaces.Repositories;

    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
            : base(empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public IEnumerable<Empresa> Consulta_CNAE(string _cnae)
        {
            return _empresaRepository.Consulta_CNAE( _cnae);
        }

        public IEnumerable<Empresa> Consulta_CNPJ(string _cnpj)
        {
            return _empresaRepository.Consulta_CNPJ(_cnpj);
        }
    }
}
