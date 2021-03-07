using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SecDE.Interfaces.Repositories
{

    using Entities;

    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        IEnumerable<Empresa> Consulta_CNPJ(string _cnpj);

        IEnumerable<Empresa> Consulta_CNAE(string _cnae);
    }
}
