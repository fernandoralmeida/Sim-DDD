using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Services.SecDE
{

    using Sim.Domain.SecDE.Entities;
    using Sim.Domain.SecDE.Interfaces.Services;
    using Sim.Domain.SecDE.Interfaces.Repositories;

    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
            : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

    }
}
