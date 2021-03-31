using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE.Interface
{
    using Sim.Domain.SDE.Entities;
    public interface IEmpresaAppService : IAppServiceBase<Empresa>
    {
        IEnumerable<Empresa> ConsultaByCNAE(string cnae);
        IEnumerable<Empresa> ConsultaByCNPJ(string cpf);
        IEnumerable<Empresa> ConsultaByRazaoSocial(string name);
    }
}
