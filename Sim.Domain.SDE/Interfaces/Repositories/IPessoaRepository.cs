using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Interfaces.Repositories
{

    using Entities;

    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        IEnumerable<Pessoa> ConsultaByNome(string _nome);
        IEnumerable<Pessoa> ConsultaByCPF(string _cpf);
    }
}
