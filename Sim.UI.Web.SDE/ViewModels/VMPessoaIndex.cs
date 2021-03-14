using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sim.UI.Web.SDE.ViewModels
{
    public class VMPessoaIndex
    {
        [DisplayName("Nome ou CPF")]
        [Required(ErrorMessage = "Nome ou CPF requerido")]
        public string NomeOuCPF { get; set; }

        public IEnumerable<VMPessoa> ListaPessoas { get; set; }
    }
}
