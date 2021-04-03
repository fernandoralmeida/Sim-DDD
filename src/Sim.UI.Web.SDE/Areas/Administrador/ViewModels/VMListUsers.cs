using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.ViewModels
{
    public class VMListUsers
    {
        [DisplayName("Username")]
        public string GetUserName { get; set; }

        public IEnumerable<VMUsers> Users { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
