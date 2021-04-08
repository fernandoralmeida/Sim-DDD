using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Services
{
    using Entities;
    using Interfaces.Services;
    using Interfaces.Repositories;

    public class AtendimentoService : ServiceBase<Atendimento>, IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
            :base(atendimentoRepository) 
        {
            _atendimentoRepository = atendimentoRepository;        
        }

        public IEnumerable<Atendimento> GetByCanal(string canal)
        {
            return _atendimentoRepository.GetByCanal(canal);
        }

        public IEnumerable<Atendimento> GetByDate(DateTime? dateTime)
        {
            return _atendimentoRepository.GetByDate(dateTime);
        }

        public IEnumerable<Atendimento> GetByEmpresa(string cnpj)
        {
            return _atendimentoRepository.GetByEmpresa(cnpj);
        }

        public IEnumerable<Atendimento> GetByPessoa(string cpf)
        {
            return _atendimentoRepository.GetByPessoa(cpf);
        }

        public IEnumerable<Atendimento> GetByServicos(string servicos)
        {
            return _atendimentoRepository.GetByServicos(servicos);
        }

        public IEnumerable<Atendimento> GetBySetor(string setor)
        {
            return _atendimentoRepository.GetBySetor(setor);
        }
    }
}
