using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.Web.SecDE.Models
{
    public class VM_Empresa_Qsa
    {
        [Key]
        public int Empresa_QSA_Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Qualificação")]
        public string Qualificacao { get; set; }

        [ScaffoldColumn(false)]
        public int Empresa_Id { get; set; }

        public virtual VM_Empresa Empresa { get; set; }
    }
}
