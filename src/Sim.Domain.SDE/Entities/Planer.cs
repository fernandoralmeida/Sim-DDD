﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Domain.SDE.Entities
{
    public class Planer
    {
        public int Id { get; set; }

        public string Segunda { get; set; }

        public string Terca { get; set; }

        public string Quarta { get; set; }

        public string Quinta { get; set; }

        public string Sexta { get; set; }

        public string Sabado { get; set; }

        public string ProximaSemana { get; set; }

        public string Prioridades { get; set; }

        public string Anotacao { get; set; }

        public DateTime? Data { get; set; }

        public DateTime? Ultima_Alteracao { get; set; }

        public bool Ativo { get; set; }

    }
}
