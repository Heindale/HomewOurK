using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LevelExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLvl",
                table: "GroupsUsers",
                newName: "UserLevel");

            migrationBuilder.RenameColumn(
                name: "UserExp",
                table: "GroupsUsers",
                newName: "UserExperience");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLevel",
                table: "GroupsUsers",
                newName: "UserLvl");

            migrationBuilder.RenameColumn(
                name: "UserExperience",
                table: "GroupsUsers",
                newName: "UserExp");
        }
    }
}
