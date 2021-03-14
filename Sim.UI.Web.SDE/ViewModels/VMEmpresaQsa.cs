using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sim.UI.Web.SDE.ViewModels
{
    public class VMEmpresaQsa
    {
        [Key]
        public int Empresa_QSA_Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Qualificação")]
        public string Qualificacao { get; set; }

        [ScaffoldColumn(false)]
        public int Empresa_Id { get; set; }

        public virtual VMEmpresa Empresa { get; set; }
    }
}
