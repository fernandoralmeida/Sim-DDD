using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        public string Evento { get; set; }

        public DateTime? Data { get; set; }

        public DateTime? Hora { get; set; }

        public string Descricao { get; set; }

        public string Owner { get; set; }

        public DateTime? Data_Cadastro { get; set; }

        public DateTime? Ultima_Alteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
