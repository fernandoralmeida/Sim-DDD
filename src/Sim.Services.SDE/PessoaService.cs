using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Services.SDE
{

    using Sim.Domain.SDE.Entities;
    using Sim.Domain.SDE.Interfaces.Services;
    using Sim.Domain.SDE.Interfaces.Repositories;

    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
            : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> ConsultaByCPF(string _cpf)
        {
            return _pessoaRepository.ConsultaByCPF(_cpf);
        }

        public IEnumerable<Pessoa> ConsultaByNome(string _nome)
        {
            return _pessoaRepository.ConsultaByNome(_nome);
        }
    }
}
