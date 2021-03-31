using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Data.Repositories.SDE
{
    using Sim.Domain.SDE.Entities;
    using Sim.Domain.SDE.Interfaces.Repositories;
    using Context;
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(DbContextSDE dbcontext) : base(dbcontext) { }

        public IEnumerable<Empresa> ConsultaByCNAE(string cnae)
        {
            return _db.SDE_Empresas.Where(p => p.CNAE_Principal == cnae);
        }

        public IEnumerable<Empresa> ConsultaByCNPJ(string cnpj)
        {
            return _db.SDE_Empresas.Where(p => p.CNPJ == cnpj);
        }

        public IEnumerable<Empresa> ConsultaByRazaoSocial(string name)
        {
            return _db.SDE_Empresas.Where(p => p.Nome_Empresarial == name || p.Nome_Fantasia == name);
        }
    }
}
