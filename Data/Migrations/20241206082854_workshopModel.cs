using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class workshopModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkshopModel",
                columns: table => new
                {
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopMax = table.Column<int>(type: "int", nullable: false),
                    WorkshopSignUps = table.Column<int>(type: "int", nullable: true),
                    WorkshopDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkshopStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkshopEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkshopTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopIMG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopModel", x => x.WorkshopId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopModel");
        }
    }
}
