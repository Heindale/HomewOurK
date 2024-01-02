using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAttahmentsAndMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Users",
                newName: "GroupsCount");

            migrationBuilder.RenameColumn(
                name: "SubjectGroupId",
                table: "Homeworks",
                newName: "SubjectsId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<int>(
                name: "Importance",
                table: "Homeworks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Homeworks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectsGroupId",
                table: "Homeworks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupType",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                columns: new[] { "Id", "GroupId", "SubjectId" });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    SubjectsId = table.Column<int>(type: "integer", nullable: true),
                    SubjectsGroupId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.Id, x.GroupId });
                    table.ForeignKey(
                        name: "FK_Attachments_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_Subjects_SubjectsId_SubjectsGroupId",
                        columns: x => new { x.SubjectsId, x.SubjectsGroupId },
                        principalTable: "Subjects",
                        principalColumns: new[] { "Id", "GroupId" });
                });

            migrationBuilder.CreateTable(
                name: "GroupsUsers",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUsers", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupsId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: true),
                    UserLevel = table.Column<int>(type: "integer", nullable: false),
                    UserExperience = table.Column<int>(type: "integer", nullable: false),
                    CompletedHomeworksCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedHomeworksCount = table.Column<int>(type: "integer", nullable: false),
                    AverageHomeworkCompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGroups_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersGroups_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectsId_SubjectsGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectsId", "SubjectsGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_GroupId",
                table: "Attachments",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_SubjectsId_SubjectsGroupId",
                table: "Attachments",
                columns: new[] { "SubjectsId", "SubjectsGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_UsersId",
                table: "GroupsUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_GroupsId",
                table: "UsersGroups",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UsersId",
                table: "UsersGroups",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectsId_SubjectsGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectsId", "SubjectsGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectsId_SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "GroupsUsers");

            migrationBuilder.DropTable(
                name: "UsersGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectsId_SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "SubjectsGroupId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "GroupType",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "GroupsCount",
                table: "Users",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "Homeworks",
                newName: "SubjectGroupId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "character varying(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Importance",
                table: "Homeworks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                columns: new[] { "Id", "GroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId_SubjectGroupId",
                table: "Homeworks",
                columns: new[] { "SubjectId", "SubjectGroupId" },
                principalTable: "Subjects",
                principalColumns: new[] { "Id", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
