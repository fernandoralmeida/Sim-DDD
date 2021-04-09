using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Entities
{
    public class Servico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Setor { get; set; }

        public string Secretaria { get; set; }

        public bool Ativo { get; set; }
    }
}
