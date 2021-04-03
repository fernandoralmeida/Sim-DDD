using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sim.Infrastructure.Data.Context
{

    using Sim.Domain.SDE.Entities;

    public class DbContextSDE : DbContext
    {

        public DbContextSDE(DbContextOptions<DbContextSDE> options) :base(options)
        {
            //this.Database.Migrate(); 
        }

        public DbSet<Pessoa> SDE_Pessoas { get; set; }
        
        public DbSet<Empresa> SDE_Empresas { get; set; }

        public DbSet<Empresa_QSA> SDE_Empresas_QSA { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Empresa_QSA>().ToTable("EmpresaQsa");

            modelBuilder.ApplyConfiguration(new EntityConfig.SDE.PessoaMap());
            modelBuilder.ApplyConfiguration(new EntityConfig.SDE.EmpresaMap());
            modelBuilder.ApplyConfiguration(new EntityConfig.SDE.EmpresaQsaMap());

            base.OnModelCreating(modelBuilder);
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
