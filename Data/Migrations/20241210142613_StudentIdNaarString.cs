using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentIdNaarString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "studentWorkshop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "studentWorkshop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
