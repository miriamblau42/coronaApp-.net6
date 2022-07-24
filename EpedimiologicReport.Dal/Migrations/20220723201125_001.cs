using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpedimiologicReport.Dal.Migrations;

public partial class _001 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Age = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.PatientId);
            });

        migrationBuilder.CreateTable(
            name: "Locations",
            columns: table => new
            {
                LocationId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Locations", x => x.LocationId);
                table.ForeignKey(
                    name: "FK_Locations_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "PatientId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Locations_PatientId",
            table: "Locations",
            column: "PatientId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Locations");

        migrationBuilder.DropTable(
            name: "Patients");
    }
}
