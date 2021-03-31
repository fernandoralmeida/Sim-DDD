using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Interfaces.Services
{
    using Entities;

    public interface IEmpresaService : IServiceBase<Empresa>
    {
        IEnumerable<Empresa> ConsultaByCNPJ(string _cnpj);

        IEnumerable<Empresa> ConsultaByCNAE(string _cnae);

        IEnumerable<Empresa> ConsultaByRazaoSocial(string _name);
    }
}
