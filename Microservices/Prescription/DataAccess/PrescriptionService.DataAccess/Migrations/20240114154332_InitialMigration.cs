using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MS_Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_Patient", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MS_Patient");
        }
    }
}
