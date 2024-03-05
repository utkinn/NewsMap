using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace NewsMap.Migrations
{
    /// <inheritdoc />
    public partial class AddFullTextSearchSupportToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Articles",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "russian")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Title", "Content" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SearchVector",
                table: "Articles",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articles_SearchVector",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Articles");
        }
    }
}
