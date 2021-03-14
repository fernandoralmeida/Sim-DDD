using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sim.Infrastructure.Data.Context
{
    using Sim.Domain.SDE.Entities;

    public class DBContextSDE : DbContext
    {
        public DBContextSDE() :base("Sim-Data-SecDE") { }

        public DbSet<Pessoa> SDE_Pessoas { get; set; }

        public DbSet<Empresa> SDE_Empresas { get; set; }

        public DbSet<Empresa_QSA> SDE_Empresas_QSA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new EntityConfig.SecDE.PessoaConfiguration());
            modelBuilder.Configurations.Add(new EntityConfig.SecDE.EmpresaConfiguration());
            modelBuilder.Configurations.Add(new EntityConfig.SecDE.EmpresaConfigurationQSA());
        }
        
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data_Cadastro") != null))
            {

                if (entry.State == EntityState.Added)
                    entry.Property("Data_Cadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("Data_Cadastro").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ultima_Alteracao") != null))
            {
                entry.Property("Ultima_Alteracao").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
        

    }
}
