using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations.User
{
    /// <inheritdoc />
    public partial class bookmarkV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitelName",
                table: "Bookmarks");

            migrationBuilder.AddColumn<int>(
                name: "TitelId",
                table: "Bookmarks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitelId",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "TitelName",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
