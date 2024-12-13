using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.RenameColumn(
                name: "inserts",
                table: "AspNetUsers",
                newName: "Inserts");

            migrationBuilder.CreateTable(
                name: "WorkshopStudents",
                columns: table => new
                {
                    IdStudentWorkshop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopStudents", x => x.IdStudentWorkshop);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopStudents");

            migrationBuilder.RenameColumn(
                name: "Inserts",
                table: "AspNetUsers",
                newName: "inserts");

            migrationBuilder.CreateTable(
                name: "studentWorkshop",
                columns: table => new
                {
                    IdStudentWorkshop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    WorkshopType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentWorkshop", x => x.IdStudentWorkshop);
                    table.ForeignKey(
                        name: "FK_studentWorkshop_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentWorkshop_WorkshopModel_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "WorkshopModel",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentWorkshop_StudentId",
                table: "studentWorkshop",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentWorkshop_WorkshopId",
                table: "studentWorkshop",
                column: "WorkshopId");
        }
    }
}
