using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanPage.Domain.Account.Migrations
{
    /// <inheritdoc />
    public partial class FolloweAndFriendV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_SubName",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_UserName",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_FriendName",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserName",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_FriendName",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_UserName",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FriendName",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_UserName",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_FriendName",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_UserName",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_Followers_SubName",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_UserName",
                table: "Followers");

            migrationBuilder.AddColumn<string>(
                name: "FriendId",
                table: "Friendships",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Friendships",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FriendId",
                table: "FriendRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FriendRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubId",
                table: "Followers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Followers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FriendId",
                table: "FriendRequests",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_SubId",
                table: "Followers",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserId",
                table: "Followers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_SubId",
                table: "Followers",
                column: "SubId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_FriendId",
                table: "FriendRequests",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserId",
                table: "FriendRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_FriendId",
                table: "Friendships",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_UserId",
                table: "Friendships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_SubId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_FriendId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_FriendId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_UserId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_FriendId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_Followers_SubId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_UserId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Followers");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendName",
                table: "Friendships",
                column: "FriendName");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserName",
                table: "Friendships",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FriendName",
                table: "FriendRequests",
                column: "FriendName");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserName",
                table: "FriendRequests",
                column: "UserName");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_FriendName",
                table: "FriendRequests",
                column: "FriendName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserName",
                table: "FriendRequests",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_FriendName",
                table: "Friendships",
                column: "FriendName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_UserName",
                table: "Friendships",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
