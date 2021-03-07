﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infra.Data.Repositories.SecDE
{
    using Sim.Domain.SecDE.Entities;
    using Sim.Domain.SecDE.Interfaces.Repositories;

    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public IEnumerable<Empresa> Consulta_CNAE(string _cnae)
        {
            return db.SDE_Empresas.Where(p => p.CNAE_Principal == _cnae);
        }

        public IEnumerable<Empresa> Consulta_CNPJ(string _cnpj)
        {
            return db.SDE_Empresas.Where(p => p.CNPJ == _cnpj);
        }
    }
}