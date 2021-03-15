using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Interfaces.Services
{
    using Entities;

    public interface IPessoaService : IServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> ConsultaByNome(string _nome);
        IEnumerable<Pessoa> ConsultaByCPF(string _cpf);
        IEnumerable<Pessoa> ConsultarPessoaByNameOrCPF(string nome_or_cpf);
    }
}
