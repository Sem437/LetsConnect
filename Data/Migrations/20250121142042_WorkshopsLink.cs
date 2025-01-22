using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkshopsLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "TemporaryWorkshopRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopTimeId",
                table: "TemporaryWorkshopRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopTimeId",
                table: "TemporaryWorkshopRegistrations");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "TemporaryWorkshopRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
