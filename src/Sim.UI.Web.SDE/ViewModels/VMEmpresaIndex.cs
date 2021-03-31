using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sim.UI.Web.SDE.ViewModels
{
    public class VMEmpresaIndex
    {
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Razao Social")]
        public string RazaoSocial { get; set; }

        public IEnumerable<VMEmpresa> ListaEmpresas { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
