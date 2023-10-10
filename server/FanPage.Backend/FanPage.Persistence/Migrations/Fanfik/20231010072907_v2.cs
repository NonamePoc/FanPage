using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanPage.Persistence.Migrations.Fanfik
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_User_UserId",
                table: "Follower");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Follower",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fanfics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginFandom",
                table: "Fanfics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Fanfics",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Fanfics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BannerUrl",
                table: "CustomizationSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FanficId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Fanfics_FanficId",
                        column: x => x.FanficId,
                        principalTable: "Fanfics",
                        principalColumn: "FanficId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sticker",
                columns: table => new
                {
                    StickerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CustomizationSettingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sticker", x => x.StickerId);
                    table.ForeignKey(
                        name: "FK_Sticker_CustomizationSettings_CustomizationSettingsId",
                        column: x => x.CustomizationSettingsId,
                        principalTable: "CustomizationSettings",
                        principalColumn: "CustomizationSettingsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FanficId",
                table: "Comments",
                column: "FanficId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sticker_CustomizationSettingsId",
                table: "Sticker",
                column: "CustomizationSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_User_UserId",
                table: "Follower",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_User_UserId",
                table: "Follower");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Sticker");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "OriginFandom",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "BannerUrl",
                table: "CustomizationSettings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Follower",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_User_UserId",
                table: "Follower",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
