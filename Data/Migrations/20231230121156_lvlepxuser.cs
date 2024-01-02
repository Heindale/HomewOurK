using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
	/// <inheritdoc />
#pragma warning disable CS8981 // Имя типа содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
	public partial class lvlepxuser : Migration
#pragma warning restore CS8981 // Имя типа содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
	{
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<int>(
				name: "UserLvl",
				table: "GroupsUsers",
				type: "integer",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "UserExp",
				table: "GroupsUsers",
				type: "integer",
				nullable: false,
				defaultValue: 0);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
				name: "UserLvl",
				table: "GroupsUsers");

			migrationBuilder.DropColumn(
				name: "UserExp",
				table: "GroupsUsers");
		}
    }
}
