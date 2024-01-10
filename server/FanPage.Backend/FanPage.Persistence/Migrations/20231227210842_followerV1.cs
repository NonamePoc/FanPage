using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Persistence.Migrations.User
{
    /// <inheritdoc />
    public partial class followerV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FollowerName",
                table: "Followers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Followers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowerName",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Followers");
        }
    }
}
