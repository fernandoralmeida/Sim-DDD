﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.Domain.SDE.Entities;

namespace Sim.Infrastructure.Data.EntityConfig.SDE
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(c => c.Empresa_Id);

            builder.HasIndex(c => c.CNPJ).IsUnique();
            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasColumnType("varchar(18)");

            builder.Property(c => c.Tipo).HasColumnType("varchar(20)");

            builder.Property(c => c.Data_Abertura).IsRequired();

            builder.Property(c => c.Nome_Empresarial)
                .IsRequired()
                .HasColumnType("varchar(150)");            

            builder.Property(c => c.Nome_Fantasia)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Porte)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.CNAE_Principal)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Atividade_Principal)
                .HasColumnType("varchar(999)");

            builder.Property(c => c.Atividade_Secundarias)
                .HasColumnType("varchar(999)");

            builder.Property(c => c.Natureza_Juridica)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.CEP)
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Numero)
                .HasColumnType("varchar(5)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Municipio)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.UF)
                .HasColumnType("varchar(2)");

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(15)");

            builder.Property(c => c.Email)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Ente_Federativo_Resp)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Situacao_Cadastral)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Data_Situacao_Cadastral);

            builder.Property(c => c.Motivo_Situacao_Cadastral)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Situacao_Especial)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Data_Situacao_Especial);

            builder.Property(c => c.Capital_Social)
                .HasColumnType("decimal");

            builder
                .HasMany(c => c.QSA)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.Empresa_Id)
                .HasForeignKey(c => c.Empresa_Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class EmpresaQsaMap : IEntityTypeConfiguration<Empresa_QSA>
    {
        public void Configure(EntityTypeBuilder<Empresa_QSA> builder)
        {
            builder.HasKey(c => c.Empresa_QSA_Id);

            builder
                .Property(c => c.Nome)
                .HasColumnType("varchar(150)");

            builder
                .Property(c => c.Qualificacao)
                .HasColumnType("varchar(50)");

            builder
                .HasOne(c => c.Empresa)
                .WithMany(c => c.QSA)
                .HasForeignKey(p => p.Empresa_Id)
                .HasPrincipalKey(p => p.Empresa_Id);

        }
    }
}
