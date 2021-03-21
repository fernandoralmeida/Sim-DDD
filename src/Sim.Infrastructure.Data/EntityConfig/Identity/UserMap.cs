using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sim.Infrastructure.Data.EntityConfig.Identity
{
    using Sim.Infrastructure.Identity.Entity;
    public class UserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            
            //builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.ToTable("AspNetUsers");
        }
    }
}
