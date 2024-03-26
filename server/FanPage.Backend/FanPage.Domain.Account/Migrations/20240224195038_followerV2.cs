using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Domain.Account.Migrations
{
    /// <inheritdoc />
    public partial class followerV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_SubcriberName",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_UserName",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_SubcriberName",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_UserName",
                table: "Follow");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Follow",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follow_UserId",
                table: "Follow",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_UserId",
                table: "Follow",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_UserId",
                table: "Follow");

            migrationBuilder.DropIndex(
                name: "IX_Follow_UserId",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Follow");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_SubcriberName",
                table: "Follow",
                column: "SubcriberName");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_UserName",
                table: "Follow",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_SubcriberName",
                table: "Follow",
                column: "SubcriberName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_UserName",
                table: "Follow",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
