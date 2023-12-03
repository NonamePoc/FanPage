using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Fanfic");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Fanfic",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Fanfic");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Fanfic",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
