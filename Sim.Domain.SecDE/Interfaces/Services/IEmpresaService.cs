using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SecDE.Interfaces.Services
{
    using Entities;

    public interface IEmpresaService : IServiceBase<Empresa>
    {
        IEnumerable<Empresa> Consulta_CNPJ(string _cnpj);

        IEnumerable<Empresa> Consulta_CNAE(string _cnae);
    }
}
