using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Domain.Account.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Photos",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea"
            );

            migrationBuilder.AlterColumn<string>(
                name: "UserAvatar",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Photos",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserAvatar",
                table: "AspNetUsers",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text"
            );
        }
    }
}
