using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE.Interface
{
    using Sim.Domain.SDE.Entities;

    public interface IPessoaAppService : IAppServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> ConsultaByNome(string _nome);
        IEnumerable<Pessoa> ConsultaByCPF(string _cpf);
        IEnumerable<Pessoa> ConsultarPessoaByNameOrCPF(string _cpf, string nome);
    }
}
