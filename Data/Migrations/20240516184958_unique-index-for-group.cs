using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class uniqueindexforgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_UniqGroupName",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UniqGroupName",
                table: "Groups",
                column: "UniqGroupName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_UniqGroupName",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UniqGroupName",
                table: "Groups",
                column: "UniqGroupName");
        }
    }
}
