using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Data.Repositories.SecDE
{
    using Sim.Domain.SDE.Interfaces.Repositories;
    using Sim.Domain.SDE.Entities;

    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public IEnumerable<Pessoa> ConsultaByCPF(string _cpf)
        {
            return db.SDE_Pessoas.Where(c => c.CPF == _cpf).OrderBy(c => c.Nome);
        }

        public IEnumerable<Pessoa> ConsultaByNome(string _nome)
        {
            return db.SDE_Pessoas.Where(c => c.Nome.Contains(_nome)).OrderBy(c => c.Nome);
        }
    }
}
