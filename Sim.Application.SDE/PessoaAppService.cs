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

        public IEnumerable<Pessoa> ConsultarPessoaByNameOrCPF(string nome_or_cpf)
        {

            var cpf = _pessoaService.ConsultaByCPF(nome_or_cpf).ToList();
            var nome = _pessoaService.ConsultaByNome(nome_or_cpf).ToList();

            if (cpf.Count > 0)

                return cpf;

            else if (nome.Count > 0)

                return nome;

            else 
                
                return null;
        }
    }
}
