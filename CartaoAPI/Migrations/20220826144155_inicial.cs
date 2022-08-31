using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoAPI.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VencimentoMes = table.Column<int>(type: "int", nullable: false),
                    VencimentoAno = table.Column<int>(type: "int", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");
        }
    }
}
