using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.ViewModels
{
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

        public string Servicos { get; set; }

        public string Descricao { get; set; }

        public string Status { get; set; }

        public DateTime? Data_Alteracao { get; set; }

        public bool Ativo { get; set; }

        public int Usuario_Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
