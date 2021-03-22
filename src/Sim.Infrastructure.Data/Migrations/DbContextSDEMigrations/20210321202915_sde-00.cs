using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sim.Infrastructure.Data.Migrations.DbContextSDEMigrations
{
    public partial class sde00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Empresa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "varchar(18)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", nullable: true),
                    Data_Abertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome_Empresarial = table.Column<string>(type: "varchar(150)", nullable: false),
                    Nome_Fantasia = table.Column<string>(type: "varchar(150)", nullable: true),
                    Porte = table.Column<string>(type: "varchar(20)", nullable: true),
                    CNAE_Principal = table.Column<string>(type: "varchar(20)", nullable: true),
                    Atividade_Principal = table.Column<string>(type: "varchar(999)", nullable: true),
                    Atividade_Secundarias = table.Column<string>(type: "varchar(999)", nullable: true),
                    Natureza_Juridica = table.Column<string>(type: "varchar(150)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(5)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(20)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Municipio = table.Column<string>(type: "varchar(50)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Ente_Federativo_Resp = table.Column<string>(type: "varchar(50)", nullable: true),
                    Situacao_Cadastral = table.Column<string>(type: "varchar(50)", nullable: true),
                    Data_Situacao_Cadastral = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Motivo_Situacao_Cadastral = table.Column<string>(type: "varchar(50)", nullable: true),
                    Situacao_Especial = table.Column<string>(type: "varchar(50)", nullable: true),
                    Data_Situacao_Especial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capital_Social = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Empresa_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Pessoa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Nome_Social = table.Column<string>(type: "varchar(150)", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    RG = table.Column<string>(type: "varchar(12)", nullable: true),
                    RG_Emissor = table.Column<string>(type: "varchar(4)", nullable: true),
                    RG_Emissor_UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deficiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(5)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(20)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    Tel_Movel = table.Column<string>(type: "varchar(15)", nullable: true),
                    Tel_Fixo = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    Data_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ultima_Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Pessoa_Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaQsa",
                columns: table => new
                {
                    Empresa_QSA_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: true),
                    Qualificacao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Empresa_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaQsa", x => x.Empresa_QSA_Id);
                    table.ForeignKey(
                        name: "FK_EmpresaQsa_Empresa_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresa",
                        principalColumn: "Empresa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_CNPJ",
                table: "Empresa",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaQsa_Empresa_Id",
                table: "EmpresaQsa",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CPF",
                table: "Pessoa",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaQsa");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
