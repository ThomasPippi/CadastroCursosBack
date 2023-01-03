using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCursos.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Enderecos_EnderecoId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Enderecos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Enderecos_EnderecoId",
                table: "Cursos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Enderecos_EnderecoId",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Enderecos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Enderecos_EnderecoId",
                table: "Cursos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId");
        }
    }
}
