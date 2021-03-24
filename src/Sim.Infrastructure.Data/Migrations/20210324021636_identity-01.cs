using Microsoft.EntityFrameworkCore.Migrations;

namespace Sim.Infrastructure.Data.Migrations
{
    public partial class identity01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SobreName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SobreName",
                table: "AspNetUsers");
        }
    }
}
