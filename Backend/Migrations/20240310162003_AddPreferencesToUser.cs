using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsMap.Migrations
{
    /// <inheritdoc />
    public partial class AddPreferencesToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserNotificationPreferences",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PushNotificationsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyAboutNearbyNews = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyAboutImportantNews = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyAboutEmergencyNews = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationPreferences", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserNotificationPreferences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTopicPreference",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopicPreference", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTopicPreference_ArticleTags_TagId",
                        column: x => x.TagId,
                        principalTable: "ArticleTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopicPreference_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicPreference_TagId",
                table: "UserTopicPreference",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotificationPreferences");

            migrationBuilder.DropTable(
                name: "UserTopicPreference");
        }
    }
}
