using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Data.Repositories.SDE
{
    using Sim.Domain.SDE.Interfaces.Repositories;
    using Sim.Domain.SDE.Entities;
    using Context;
    public class AtendimentoRepository: RepositoryBase<Atendimento>, IAtendimentoRepository
    {

        public AtendimentoRepository(DbContextSDE dbContextSDE)
            : base(dbContextSDE) { }

        public IEnumerable<Atendimento> GetByCanal(string canal)
        {
            return _db.Atendimentos.Where(c => c.Canal.Contains(canal));
        }

        public IEnumerable<Atendimento> GetByDate(DateTime? dateTime)
        {
            return _db.Atendimentos.Where(c => c.Data == dateTime);
        }

        public IEnumerable<Atendimento> GetByEmpresa(string cnpj)
        {
            var empresa = _db.SDE_Empresas.Where(c => c.CNPJ == cnpj).ToList();

            List<Atendimento> lt = new();

            foreach(Empresa e in empresa)
            {
                lt = _db.Atendimentos.Where(c => c.Empresa_Id == e.Empresa_Id).ToList();
            }

            return lt;
        }

        public IEnumerable<Atendimento> GetByPessoa(string cpf)
        {
            var pessoa = _db.SDE_Pessoas.Where(c => c.CPF == cpf).ToList();

            List<Atendimento> lt = new();

            foreach (Pessoa e in pessoa)
            {
                lt = _db.Atendimentos.Where(c => c.Pessoa_Id == e.Pessoa_Id).ToList();
            }

            return lt;
        }

        public IEnumerable<Atendimento> GetByServicos(string servicos)
        {
            return _db.Atendimentos.Where(c => c.Canal.Contains(servicos));
        }

        public IEnumerable<Atendimento> GetBySetor(string setor)
        {
            return _db.Atendimentos.Where(c => c.Canal.Contains(setor));
        }
    }
}
