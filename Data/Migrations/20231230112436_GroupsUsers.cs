using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GroupsUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupsUsers_Groups_GroupsId",
            //    table: "GroupsUsers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupsUsers_Users_UsersId",
            //    table: "GroupsUsers");

            //migrationBuilder.DropTable(
            //    name: "UsersGroups");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_GroupsUsers",
            //    table: "GroupsUsers");

            //migrationBuilder.DropIndex(
            //    name: "IX_GroupsUsers_UsersId",
            //    table: "GroupsUsers");

            //migrationBuilder.RenameColumn(
            //    name: "UserId",
            //    table: "GroupsUsers",
            //    newName: "UserLevel");

            //migrationBuilder.RenameColumn(
            //    name: "GroupId",
            //    table: "GroupsUsers",
            //    newName: "UserExperience");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "GroupsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GroupsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AverageHomeworkCompletionTime",
                table: "GroupsUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompletedHomeworksCount",
                table: "GroupsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedHomeworksCount",
                table: "GroupsUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupsUsers",
                table: "GroupsUsers",
                columns: new[] { "GroupId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_UserId",
                table: "GroupsUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Groups_GroupId",
                table: "GroupsUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Users_UserId",
                table: "GroupsUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupsUsers_Groups_GroupId",
            //    table: "GroupsUsers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_GroupsUsers_Users_UserId",
            //    table: "GroupsUsers");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_GroupsUsers",
            //    table: "GroupsUsers");

            //migrationBuilder.DropIndex(
            //    name: "IX_GroupsUsers_UserId",
            //    table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "AverageHomeworkCompletionTime",
                table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "CompletedHomeworksCount",
                table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "CreatedHomeworksCount",
                table: "GroupsUsers");

            migrationBuilder.RenameColumn(
                name: "UserLevel",
                table: "GroupsUsers",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "UserExperience",
                table: "GroupsUsers",
                newName: "GroupsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupsUsers",
                table: "GroupsUsers",
                columns: new[] { "GroupsId", "UsersId" });

            //migrationBuilder.CreateTable(
            //    name: "UsersGroups",
            //    columns: table => new
            //    {
            //        GroupId = table.Column<int>(type: "integer", nullable: false),
            //        UserId = table.Column<int>(type: "integer", nullable: false),
            //        AverageHomeworkCompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        CompletedHomeworksCount = table.Column<int>(type: "integer", nullable: false),
            //        CreatedHomeworksCount = table.Column<int>(type: "integer", nullable: false),
            //        UserExperience = table.Column<int>(type: "integer", nullable: false),
            //        UserLevel = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UsersGroups", x => new { x.GroupId, x.UserId });
            //        table.ForeignKey(
            //            name: "FK_UsersGroups_Groups_GroupId",
            //            column: x => x.GroupId,
            //            principalTable: "Groups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UsersGroups_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_UsersId",
                table: "GroupsUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Groups_GroupsId",
                table: "GroupsUsers",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Users_UsersId",
                table: "GroupsUsers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
