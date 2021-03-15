using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Services
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

        public IEnumerable<Pessoa> ConsultarPessoaByNameOrCPF(string nome_or_cpf)
        {
            var cpf = _pessoaRepository.ConsultaByCPF(nome_or_cpf).ToList();
            var nome = _pessoaRepository.ConsultaByNome(nome_or_cpf).ToList();

            if (cpf.Count > 0)

                return cpf;

            else if (nome.Count > 0)

                return nome;

            else

                return _pessoaRepository.GetAll();
        }
    }
}
