using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE
{
    using Sim.Domain.SDE.Entities;
    using Sim.Application.SDE.Interface;
    using Sim.Domain.SDE.Interfaces.Services;
    public class AtendimentoAppService : AppServiceBase<Atendimento>, IAtendimentoAppService
    {

        public readonly IAtendimentoService _atendimentoService;

        public AtendimentoAppService(IAtendimentoService atendimentoService)
            :base(atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        public IEnumerable<Atendimento> GetByCanal(string canal)
        {
            return _atendimentoService.GetByCanal(canal);
        }

        public IEnumerable<Atendimento> GetByDate(DateTime? dateTime)
        {
            return _atendimentoService.GetByDate(dateTime);
        }

        public IEnumerable<Atendimento> GetByEmpresa(string cnpj)
        {
            return _atendimentoService.GetByEmpresa(cnpj);
        }

        public IEnumerable<Atendimento> GetByPessoa(string cpf)
        {
            return _atendimentoService.GetByPessoa(cpf);
        }

        public IEnumerable<Atendimento> GetByServicos(string servicos)
        {
            return _atendimentoService.GetByServicos("servicos");
        }

        public IEnumerable<Atendimento> GetBySetor(string setor)
        {
            return _atendimentoService.GetBySetor(setor);
        }
    }
}
