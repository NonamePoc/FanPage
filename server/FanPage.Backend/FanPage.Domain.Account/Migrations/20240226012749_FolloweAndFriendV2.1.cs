using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Domain.Account.Migrations
{
    /// <inheritdoc />
    public partial class FolloweAndFriendV21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_UserId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Followers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Followers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubName",
                table: "Followers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followers_SubName",
                table: "Followers",
                column: "SubName");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserName",
                table: "Followers",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_SubName",
                table: "Followers",
                column: "SubName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_UserName",
                table: "Followers",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_SubName",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_UserName",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_SubName",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_UserName",
                table: "Followers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Followers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SubName",
                table: "Followers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Followers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserId",
                table: "Followers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
