using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSalaoDeBeleza.Migrations
{
    public partial class Setor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    SetorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.SetorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SetorId",
                table: "Funcionarios",
                column: "SetorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Setores_SetorId",
                table: "Funcionarios",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "SetorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Setores_SetorId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SetorId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "Funcionarios");
        }
    }
}
