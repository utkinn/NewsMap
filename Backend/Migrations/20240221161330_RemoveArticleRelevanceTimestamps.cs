using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsMap.Migrations
{
    /// <inheritdoc />
    public partial class RemoveArticleRelevanceTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelevantFrom",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "RelevantTo",
                table: "Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RelevantFrom",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RelevantTo",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
