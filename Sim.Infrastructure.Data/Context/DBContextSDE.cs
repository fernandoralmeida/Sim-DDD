﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sim.Infrastructure.Data.Context
{

    using Sim.Domain.SDE.Entities;

    public class DBContextSDE : DbContext
    {
        public DBContextSDE(DbContextOptions<DBContextSDE> options) :base(options) { }

        public DbSet<Pessoa> SDE_Pessoas { get; set; }
        
        public DbSet<Empresa> SDE_Empresas { get; set; }

        public DbSet<Empresa_QSA> SDE_Empresas_QSA { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Empresa_QSA>().ToTable("EmpresaQsa");

            modelBuilder.ApplyConfiguration(new EntityConfig.SecDE.PessoaMap());
            modelBuilder.ApplyConfiguration(new EntityConfig.SecDE.EmpresaMap());
            modelBuilder.ApplyConfiguration(new EntityConfig.SecDE.EmpresaQsaMap());

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
