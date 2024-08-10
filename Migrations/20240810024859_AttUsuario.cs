using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AttUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas");

            migrationBuilder.RenameTable(
                name: "Vagas",
                newName: "tb_vaga");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_vaga",
                table: "tb_vaga",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_vaga",
                table: "tb_vaga");

            migrationBuilder.RenameTable(
                name: "tb_vaga",
                newName: "Vagas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas",
                column: "Id");
        }
    }
}
