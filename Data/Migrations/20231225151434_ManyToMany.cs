using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "Curricula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "SubjectGroupId",
                table: "Homeworks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                columns: new[] { "Id", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                columns: new[] { "Id", "GroupId" });

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
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsTeachers_TeachersId_TeachersGroupId",
                table: "SubjectsTeachers",
                columns: new[] { "TeachersId", "TeachersGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "SubjectsTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Curricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectId = table.Column<int>(type: "integer", nullable: true),
                    TeacherId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curricula_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Curricula_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectId",
                table: "Homeworks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_SubjectId",
                table: "Curricula",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_TeacherId",
                table: "Curricula",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
