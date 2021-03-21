using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sim.Infrastructure.Identity.Model
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        //public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}