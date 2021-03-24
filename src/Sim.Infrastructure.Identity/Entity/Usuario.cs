using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Identity.Entity
{
    public class Usuario : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

    }
}
