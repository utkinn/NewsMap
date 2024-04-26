using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsMap.Migrations
{
    /// <inheritdoc />
    public partial class FixUserTopicPreferencePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference",
                columns: new[] { "UserId", "TagId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference",
                column: "UserId");
        }
    }
}
