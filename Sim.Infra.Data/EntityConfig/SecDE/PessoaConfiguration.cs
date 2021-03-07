﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Sim.Domain.SecDE.Entities;

namespace Sim.Infra.Data.EntityConfig.SecDE
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(c => c.Pessoa_Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Nome_Social)
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Data_Nascimento)
                .IsRequired();

            Property(c => c.RG)
                .HasMaxLength(10);

            Property(c => c.RG_Emissor)
                .HasMaxLength(5);

            Property(c => c.RG_Emissor_UF)
                .HasMaxLength(2);

            Property(c => c.CEP)
                .HasMaxLength(8);

            Property(c => c.UF)
                .HasMaxLength(2);

            Property(c => c.Tel_Fixo)
                .HasMaxLength(10);

            Property(c => c.Tel_Movel)
                .HasMaxLength(11);

            Property(c => c.Data_Cadastro)
                .IsRequired();

            Property(c => c.Ultima_Alteracao)
                .IsRequired();

            //HasRequired(p => p.Empresas)
            //.WithMany()
            //.HasForeignKey(p => p.Empresa_Id);

        }

    }
}