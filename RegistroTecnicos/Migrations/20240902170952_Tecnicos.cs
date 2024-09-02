﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Tecnicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tecnicos",
                columns: table => new
                {
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    SueldoHora = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tecnicos", x => x.TecnicoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tecnicos");
        }
    }
}
