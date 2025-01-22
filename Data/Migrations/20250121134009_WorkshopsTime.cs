using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkshopsTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopDate",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "WorkshopEndTime",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "WorkshopPlace",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "WorkshopRonde",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "WorkshopStartTime",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "WorkshopTeacher",
                table: "WorkshopModel");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopTimeId",
                table: "WorkshopStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkshopTimes",
                columns: table => new
                {
                    WorkshopTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    WorkshopRonde = table.Column<int>(type: "int", nullable: false),
                    WorkshopPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkshopStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkshopEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkshopTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopTimes", x => x.WorkshopTimeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopTimes");

            migrationBuilder.DropColumn(
                name: "WorkshopTimeId",
                table: "WorkshopStudents");

            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkshopDate",
                table: "WorkshopModel",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "WorkshopEndTime",
                table: "WorkshopModel",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "WorkshopPlace",
                table: "WorkshopModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopRonde",
                table: "WorkshopModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "WorkshopStartTime",
                table: "WorkshopModel",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "WorkshopTeacher",
                table: "WorkshopModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
