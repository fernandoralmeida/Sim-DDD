using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Interfaces.Services
{
    using Entities;
    public interface IAtendimentoService : IServiceBase<Atendimento>
    {
        IEnumerable<Atendimento> GetByPessoa(string cpf);

        IEnumerable<Atendimento> GetByEmpresa(string cnpj);

        IEnumerable<Atendimento> GetBySetor(string setor);

        IEnumerable<Atendimento> GetByCanal(string canal);

        IEnumerable<Atendimento> GetByServicos(string servicos);

        IEnumerable<Atendimento> GetByDate(DateTime? dateTime);
    }
}
