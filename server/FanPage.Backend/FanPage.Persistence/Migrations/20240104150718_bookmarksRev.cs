using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations.User
{
    /// <inheritdoc />
    public partial class bookmarksRev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitelName",
                table: "Bookmarks",
                newName: "TitelId");

            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Bookmarks");

            migrationBuilder.RenameColumn(
                name: "TitelId",
                table: "Bookmarks",
                newName: "TitelName");
        }
    }
}
