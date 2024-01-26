using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations.User
{
    /// <inheritdoc />
    public partial class bookmarkV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitelId",
                table: "Bookmarks",
                newName: "TitelName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitelName",
                table: "Bookmarks",
                newName: "TitelId");
        }
    }
}
