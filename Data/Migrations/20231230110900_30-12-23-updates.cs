using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _301223updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Subjects_SubjectsId_SubjectsGroupId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectsId_SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Groups_GroupsId",
                table: "UsersGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Users_UsersId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroups_GroupsId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroups_UsersId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectsId_SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_SubjectsId_SubjectsGroupId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "UsersGroups");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UsersGroups");

            migrationBuilder.DropColumn(
                name: "SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "SubjectsGroupId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "Homeworks",
                newName: "SubjectGroupId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "Attachments",
                newName: "SubjectGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_SubjectId_SubjectGroupId",
                table: "Attachments",
                columns: new[] { "SubjectId", "SubjectGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Subjects_SubjectId_SubjectGroupId",
                table: "Attachments",
                columns: new[] { "SubjectId", "SubjectGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Subjects_SubjectId_SubjectGroupId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_SubjectId_SubjectGroupId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "SubjectGroupId",
                table: "Homeworks",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "SubjectGroupId",
                table: "Attachments",
                newName: "SubjectsId");

            migrationBuilder.AddColumn<int>(
                name: "GroupsId",
                table: "UsersGroups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UsersGroups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectsGroupId",
                table: "Homeworks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectsGroupId",
                table: "Attachments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_GroupsId",
                table: "UsersGroups",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UsersId",
                table: "UsersGroups",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectsId_SubjectsGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectsId", "SubjectsGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_SubjectsId_SubjectsGroupId",
                table: "Attachments",
                columns: new[] { "SubjectsId", "SubjectsGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Subjects_SubjectsId_SubjectsGroupId",
                table: "Attachments",
                columns: new[] { "SubjectsId", "SubjectsGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectsId_SubjectsGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectsId", "SubjectsGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Groups_GroupsId",
                table: "UsersGroups",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Users_UsersId",
                table: "UsersGroups",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
