using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sim.Infrastructure.Data.EntityConfig.SDE
{
    using Sim.Domain.SDE.Entities;
    public class AtendimentoMap: IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(c => c.Atendimento_Id);
            builder.HasIndex(c => c.Protocolo).IsUnique();
            builder.Property(c => c.Protocolo)
                .IsRequired();
            builder.Property(c => c.Data);
            builder.Property(c => c.Inicio);
            builder.Property(c => c.Fim);
            builder.Property(c => c.Pessoa_Id);
            builder.Property(c => c.Empresa_Id);
            builder.Property(c => c.Setor)
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Canal)
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Servicos)
                .HasColumnType("varchar(150)");
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(150)");
            builder.Property(c => c.Status)
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Data_Alteracao);
            builder.Property(c => c.Ativo);
            builder.Property(c => c.Usuario_Id);

        }
    }
}
