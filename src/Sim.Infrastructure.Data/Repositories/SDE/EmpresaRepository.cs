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

        public IEnumerable<Empresa> Consulta_CNAE(string _cnae)
        {
            return _db.SDE_Empresas.Where(p => p.CNAE_Principal == _cnae);
        }

        public IEnumerable<Empresa> Consulta_CNPJ(string _cnpj)
        {
            return _db.SDE_Empresas.Where(p => p.CNPJ == _cnpj);
        }
    }
}
