using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations.User
{
    /// <inheritdoc />
    public partial class bookmarksV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FanficReadingId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "TitelName",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitelName",
                table: "Bookmarks");

            migrationBuilder.AddColumn<int>(
                name: "FanficReadingId",
                table: "Bookmarks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Bookmarks",
                type: "text",
                nullable: true);
        }
    }
}
