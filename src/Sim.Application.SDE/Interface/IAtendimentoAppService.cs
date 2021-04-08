using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.SDE.Interface
{
    using Sim.Domain.SDE.Entities;
    public interface IAtendimentoAppService : IAppServiceBase<Atendimento>
    {
        IEnumerable<Atendimento> GetByPessoa(string cpf);

        IEnumerable<Atendimento> GetByEmpresa(string cnpj);

        IEnumerable<Atendimento> GetBySetor(string setor);

        IEnumerable<Atendimento> GetByCanal(string canal);

        IEnumerable<Atendimento> GetByServicos(string servicos);

        IEnumerable<Atendimento> GetByDate(DateTime? dateTime);
    }
}
