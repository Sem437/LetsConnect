using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class TempWorkshopModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "WorkshopStudents",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "TemporaryWorkshopRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConformationToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryWorkshopRegistrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporaryWorkshopRegistrations");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "WorkshopStudents",
                newName: "StudentId");
        }
    }
}
