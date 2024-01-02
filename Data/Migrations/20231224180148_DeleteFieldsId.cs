using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFieldsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_Subjects_SubjectId1",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_Teachers_TeacherId1",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Groups_GroupId1",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId1",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_GroupId1",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId1",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId1",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Users",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId1",
                table: "Users",
                newName: "IX_Users_GroupId");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Teachers",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_GroupId1",
                table: "Teachers",
                newName: "IX_Teachers_GroupId");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Subjects",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_GroupId1",
                table: "Subjects",
                newName: "IX_Subjects_GroupId");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "Homeworks",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Homeworks",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_SubjectId1",
                table: "Homeworks",
                newName: "IX_Homeworks_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_GroupId1",
                table: "Homeworks",
                newName: "IX_Homeworks_GroupId");

            migrationBuilder.RenameColumn(
                name: "TeacherId1",
                table: "Curricula",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "Curricula",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Curricula_TeacherId1",
                table: "Curricula",
                newName: "IX_Curricula_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Curricula_SubjectId1",
                table: "Curricula",
                newName: "IX_Curricula_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_Subjects_SubjectId",
                table: "Curricula",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_Teachers_TeacherId",
                table: "Curricula",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Groups_GroupId",
                table: "Homeworks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_GroupId",
                table: "Subjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_Subjects_SubjectId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_Teachers_TeacherId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Groups_GroupId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_GroupId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Users",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                newName: "IX_Users_GroupId1");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Teachers",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                newName: "IX_Teachers_GroupId1");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Subjects",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_GroupId",
                table: "Subjects",
                newName: "IX_Subjects_GroupId1");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Homeworks",
                newName: "SubjectId1");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Homeworks",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_SubjectId",
                table: "Homeworks",
                newName: "IX_Homeworks_SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_GroupId",
                table: "Homeworks",
                newName: "IX_Homeworks_GroupId1");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Curricula",
                newName: "TeacherId1");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Curricula",
                newName: "SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_Curricula_TeacherId",
                table: "Curricula",
                newName: "IX_Curricula_TeacherId1");

            migrationBuilder.RenameIndex(
                name: "IX_Curricula_SubjectId",
                table: "Curricula",
                newName: "IX_Curricula_SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_Subjects_SubjectId1",
                table: "Curricula",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_Teachers_TeacherId1",
                table: "Curricula",
                column: "TeacherId1",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Groups_GroupId1",
                table: "Homeworks",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId1",
                table: "Homeworks",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_GroupId1",
                table: "Subjects",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId1",
                table: "Teachers",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId1",
                table: "Users",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
