using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicoss.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tecnicos_TipoId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "IncentivoId",
                table: "TipoTecnico");

            migrationBuilder.AlterColumn<decimal>(
                name: "Incentivo",
                table: "TipoTecnico",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IncentivoId",
                table: "Tecnicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tecnicosTecnicoId",
                table: "IncentivosTecnicos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TipoId",
                table: "Tecnicos",
                column: "TipoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncentivosTecnicos_tecnicosTecnicoId",
                table: "IncentivosTecnicos",
                column: "tecnicosTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncentivosTecnicos_Tecnicos_tecnicosTecnicoId",
                table: "IncentivosTecnicos",
                column: "tecnicosTecnicoId",
                principalTable: "Tecnicos",
                principalColumn: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncentivosTecnicos_Tecnicos_tecnicosTecnicoId",
                table: "IncentivosTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_Tecnicos_TipoId",
                table: "Tecnicos");

            migrationBuilder.DropIndex(
                name: "IX_IncentivosTecnicos_tecnicosTecnicoId",
                table: "IncentivosTecnicos");

            migrationBuilder.DropColumn(
                name: "IncentivoId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "tecnicosTecnicoId",
                table: "IncentivosTecnicos");

            migrationBuilder.AlterColumn<int>(
                name: "Incentivo",
                table: "TipoTecnico",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncentivoId",
                table: "TipoTecnico",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TipoId",
                table: "Tecnicos",
                column: "TipoId");
        }
    }
}
