using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sim.UI.Web.SDE.Areas.Administrador.ViewModels
{
    public class VMRoleClaims
    {
        public int Id { get; set; }
        
        public string RoleId { get; set; }
                   
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
