using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE
{
    using Sim.Domain.SDE.Entities;
    using Interface;
    using Sim.Domain.SDE.Interfaces.Services;

    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaService pessoaService)
            : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IEnumerable<Pessoa> ConsultaByCPF(string _cpf)
        {
            return _pessoaService.ConsultaByCPF(_cpf);
        }

        public IEnumerable<Pessoa> ConsultaByNome(string _nome)
        {
            return _pessoaService.ConsultaByNome(_nome);
        }

        public IEnumerable<Pessoa> ConsultarPessoaByNameOrCPF(string nome_or_cpf)
        {

            return _pessoaService.ConsultarPessoaByNameOrCPF(nome_or_cpf);
        }
    }
}
