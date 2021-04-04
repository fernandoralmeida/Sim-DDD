using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sim.Infrastructure.Identity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.ViewModels
{
    public class VMUserRoles : Usuario
    {
        public string RoleId { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        public List<IdentityRole> ListRoles { get; set; } 

        public string StatusMessage { get; set; }
    }
}
