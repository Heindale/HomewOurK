using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeindexusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectsTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Username",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "integer", nullable: false),
                    SubjectsGroupId = table.Column<int>(type: "integer", nullable: false),
                    TeachersId = table.Column<int>(type: "integer", nullable: false),
                    TeachersGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.SubjectsGroupId, x.TeachersId, x.TeachersGroupId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsId_SubjectsGroupId",
                        columns: x => new { x.SubjectsId, x.SubjectsGroupId },
                        principalTable: "Subjects",
                        principalColumns: new[] { "Id", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersId_TeachersGroupId",
                        columns: x => new { x.TeachersId, x.TeachersGroupId },
                        principalTable: "Teachers",
                        principalColumns: new[] { "Id", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId_TeachersGroupId",
                table: "SubjectTeacher",
                columns: new[] { "TeachersId", "TeachersGroupId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.CreateTable(
                name: "SubjectsTeachers",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "integer", nullable: false),
                    SubjectsGroupId = table.Column<int>(type: "integer", nullable: false),
                    TeachersId = table.Column<int>(type: "integer", nullable: false),
                    TeachersGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsTeachers", x => new { x.SubjectsId, x.SubjectsGroupId, x.TeachersId, x.TeachersGroupId });
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Subjects_SubjectsId_SubjectsGroupId",
                        columns: x => new { x.SubjectsId, x.SubjectsGroupId },
                        principalTable: "Subjects",
                        principalColumns: new[] { "Id", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Teachers_TeachersId_TeachersGroupId",
                        columns: x => new { x.TeachersId, x.TeachersGroupId },
                        principalTable: "Teachers",
                        principalColumns: new[] { "Id", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Username",
                table: "Users",
                columns: new[] { "Email", "Username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsTeachers_TeachersId_TeachersGroupId",
                table: "SubjectsTeachers",
                columns: new[] { "TeachersId", "TeachersGroupId" });
        }
    }
}
