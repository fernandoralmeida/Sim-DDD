using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Interfaces.Repositories
{

    using Entities;

    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        IEnumerable<Empresa> ConsultaByCNPJ(string _cnpj);

        IEnumerable<Empresa> ConsultaByCNAE(string _cnae);

        IEnumerable<Empresa> ConsultaByRazaoSocial(string _name);
    }
}
