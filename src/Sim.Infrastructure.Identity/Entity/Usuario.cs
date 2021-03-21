using Microsoft.AspNetCore.Identity;


namespace Sim.Infrastructure.Identity.Entity
{
    public class Usuario : IdentityUser
    {
        public string Name { get; set; }
        public string Genero { get; set; }
    }
}
