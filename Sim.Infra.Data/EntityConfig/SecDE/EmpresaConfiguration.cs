using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Sim.Domain.SecDE.Entities;

namespace Sim.Infra.Data.EntityConfig.SecDE
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(c => c.Empresa_Id);

            Property(c => c.Nome_Empresarial)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Data_Abertura).IsRequired();

            Property(c => c.Nome_Fantasia)
                .HasMaxLength(150);

            Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.CEP)
                .HasMaxLength(8);

            Property(c => c.UF)
                .HasMaxLength(2);

            Property(c => c.Telefone)
                .HasMaxLength(11);

            Property(c => c.Data_Situacao_Cadastral).IsRequired();
            Property(c => c.Data_Situacao_Especial).IsRequired();

            //HasRequired(p => p.Clientes)
            //.WithMany()
            //.HasForeignKey(p => p.Cliente_Id);
        }
    }

    public class EmpresaConfigurationQSA : EntityTypeConfiguration<Empresa_QSA>
    {
        public EmpresaConfigurationQSA()
        {
            HasKey(c => c.Empresa_QSA_Id);

            Property(c => c.Nome).HasMaxLength(150);
            Property(c => c.Qualificacao).HasMaxLength(150);

            //Registro relacional 1 Empresa varios QSA
            HasRequired(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.Empresa_Id);

        }
    }
}
