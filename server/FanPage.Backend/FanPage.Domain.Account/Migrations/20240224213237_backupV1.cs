using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanPage.Domain.Account.Migrations
{
    /// <inheritdoc />
    public partial class backupV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Friendships",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FriendName",
                table: "Friendships",
                newName: "FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserName",
                table: "Friendships",
                newName: "IX_Friendships_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_FriendName",
                table: "Friendships",
                newName: "IX_Friendships_FriendId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "FriendRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FriendName",
                table: "FriendRequests",
                newName: "FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_UserName",
                table: "FriendRequests",
                newName: "IX_FriendRequests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_FriendName",
                table: "FriendRequests",
                newName: "IX_FriendRequests_FriendId");

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.FollowerId);
                    table.ForeignKey(
                        name: "FK_Followers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserId",
                table: "Followers",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Friendships",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "Friendships",
                newName: "FriendName");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships",
                newName: "IX_Friendships_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                newName: "IX_Friendships_FriendName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FriendRequests",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "FriendRequests",
                newName: "FriendName");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_FriendId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_FriendName");

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    SubcriberName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.FollowerId);
                    table.ForeignKey(
                        name: "FK_Follow_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follow_UserId",
                table: "Follow",
                column: "UserId");

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
