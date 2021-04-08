using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using Sim.Domain.SDE.Entities;
    using System.ComponentModel.DataAnnotations;

    public class VMAtendimentoIndex
    {
        [DataType(DataType.Date)]
        public DateTime? DataAtendimento { get; set; }

        public IEnumerable<Atendimento> ListaAtendimento { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
