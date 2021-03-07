using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infra.Data.Repositories.SecDE
{
    using Sim.Domain.SecDE.Interfaces.Repositories;
    using Sim.Domain.SecDE.Entities;

    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
    }
}
