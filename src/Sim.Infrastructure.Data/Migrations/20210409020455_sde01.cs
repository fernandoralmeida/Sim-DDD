using Microsoft.EntityFrameworkCore.Migrations;

namespace Sim.Infrastructure.Data.Migrations
{
    public partial class sde01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario_Id",
                table: "Atendimento");

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "Atendimento",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Canal",
                table: "Atendimento",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Atendimento",
                type: "varchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Atendimento");

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "Atendimento",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Canal",
                table: "Atendimento",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Usuario_Id",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
