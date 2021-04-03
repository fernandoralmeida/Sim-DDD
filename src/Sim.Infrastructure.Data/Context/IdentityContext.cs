using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sim.Infrastructure.Data.Context
{

    using Sim.Infrastructure.Identity.Entity;

    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            :base(options)
        {
            //this.Database.Migrate();      
        
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new EntityConfig.Identity.UserMap());
            base.OnModelCreating(modelbuilder);
        }
    }
}
