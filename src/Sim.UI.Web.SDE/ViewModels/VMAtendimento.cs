using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.ViewModels
{
    using Sim.Domain.SDE.Entities;

    public class VMAtendimentoBase
    {
        [TempData]
        public string StatusMessage { get; set; }

        public Pessoa Pessoa { get; set; }
        
        public Empresa Empresa { get; set; }

        public List<Setor> Setores { get; set; }

        public List<Canal> Canais { get; set; }

        public List<Servico> Servicos { get; set; }

        public VMAtendimento Atendimento { get; set; }
    }

    public class VMAtendimento
    {
        public int Atendimento_Id { get; set; }

        public int Protocolo { get; set; }

        public DateTime? Data { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Fim { get; set; }

        public int Pessoa_Id { get; set; }

        public int Empresa_Id { get; set; }

        public string Setor { get; set; }

        public string Canal { get; set; }

        public string Servico { get; set; }

        public string Descricao { get; set; }

        public string Status { get; set; }

        public DateTime? Data_Alteracao { get; set; }

        public bool Ativo { get; set; }

        public string UserName { get; set; }

    }
}
