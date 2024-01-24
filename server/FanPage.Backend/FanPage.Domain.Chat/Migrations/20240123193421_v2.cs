using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Domain.Chat.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptedRequest",
                table: "ChatUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Chats",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Chats",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedRequest",
                table: "ChatUsers");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Chats");
        }
    }
}
