﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sim.Infrastructure.Data.Context;

namespace Sim.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DbContextSDE))]
    partial class DbContextSDEModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Atendimento", b =>
                {
                    b.Property<int>("Atendimento_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Canal")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Empresa_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pessoa_Id")
                        .HasColumnType("int");

                    b.Property<int>("Protocolo")
                        .HasColumnType("int");

                    b.Property<string>("Servicos")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Setor")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Atendimento_Id");

                    b.HasIndex("Protocolo")
                        .IsUnique();

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Empresa", b =>
                {
                    b.Property<int>("Empresa_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Atividade_Principal")
                        .HasColumnType("varchar(999)");

                    b.Property<string>("Atividade_Secundarias")
                        .HasColumnType("varchar(999)");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CNAE_Principal")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<decimal>("Capital_Social")
                        .HasColumnType("decimal");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("Data_Abertura")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Situacao_Cadastral")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Situacao_Especial")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Ente_Federativo_Resp")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Motivo_Situacao_Cadastral")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Municipio")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Natureza_Juridica")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome_Empresarial")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome_Fantasia")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Porte")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Situacao_Cadastral")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Situacao_Especial")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Empresa_Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Empresa_QSA", b =>
                {
                    b.Property<int>("Empresa_QSA_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Empresa_Id")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Qualificacao")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Empresa_QSA_Id");

                    b.HasIndex("Empresa_Id");

                    b.ToTable("EmpresaQsa");
                });

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Pessoa", b =>
                {
                    b.Property<int>("Pessoa_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("Data_Cadastro")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Nascimento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Deficiencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome_Social")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("RG")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("RG_Emissor")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("RG_Emissor_UF")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Tel_Fixo")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Tel_Movel")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2)");

                    b.Property<DateTime?>("Ultima_Alteracao")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Pessoa_Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Empresa_QSA", b =>
                {
                    b.HasOne("Sim.Domain.SDE.Entities.Empresa", "Empresa")
                        .WithMany("QSA")
                        .HasForeignKey("Empresa_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Sim.Domain.SDE.Entities.Empresa", b =>
                {
                    b.Navigation("QSA");
                });
#pragma warning restore 612, 618
        }
    }
}