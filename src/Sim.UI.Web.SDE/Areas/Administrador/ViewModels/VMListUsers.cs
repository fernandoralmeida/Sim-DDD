using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.ViewModels
{
    using Sim.Infrastructure.Identity.Entity;
    public class VMListUsers
    {
        [DisplayName("Procurar por Id")]
        public string GetUserName { get; set; }

        public IEnumerable<Usuario> Users { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
