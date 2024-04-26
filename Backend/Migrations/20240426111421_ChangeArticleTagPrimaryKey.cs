using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewsMap.Migrations
{
    /// <inheritdoc />
    public partial class ChangeArticleTagPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleArticleTag_ArticleTags_TagsId",
                table: "ArticleArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTopicPreference_ArticleTags_TagId",
                table: "UserTopicPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference");

            migrationBuilder.DropIndex(
                name: "IX_UserTopicPreference_TagId",
                table: "UserTopicPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleArticleTag",
                table: "ArticleArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_ArticleArticleTag_TagsId",
                table: "ArticleArticleTag");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "UserTopicPreference");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArticleTags");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "ArticleArticleTag");

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "UserTopicPreference",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TagsName",
                table: "ArticleArticleTag",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference",
                columns: new[] { "UserId", "TagName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleArticleTag",
                table: "ArticleArticleTag",
                columns: new[] { "ArticlesId", "TagsName" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicPreference_TagName",
                table: "UserTopicPreference",
                column: "TagName");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleArticleTag_TagsName",
                table: "ArticleArticleTag",
                column: "TagsName");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleArticleTag_ArticleTags_TagsName",
                table: "ArticleArticleTag",
                column: "TagsName",
                principalTable: "ArticleTags",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTopicPreference_ArticleTags_TagName",
                table: "UserTopicPreference",
                column: "TagName",
                principalTable: "ArticleTags",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleArticleTag_ArticleTags_TagsName",
                table: "ArticleArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTopicPreference_ArticleTags_TagName",
                table: "UserTopicPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference");

            migrationBuilder.DropIndex(
                name: "IX_UserTopicPreference_TagName",
                table: "UserTopicPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleArticleTag",
                table: "ArticleArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_ArticleArticleTag_TagsName",
                table: "ArticleArticleTag");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "UserTopicPreference");

            migrationBuilder.DropColumn(
                name: "TagsName",
                table: "ArticleArticleTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "UserTopicPreference",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ArticleTags",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "ArticleArticleTag",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTopicPreference",
                table: "UserTopicPreference",
                columns: new[] { "UserId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleArticleTag",
                table: "ArticleArticleTag",
                columns: new[] { "ArticlesId", "TagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicPreference_TagId",
                table: "UserTopicPreference",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleArticleTag_TagsId",
                table: "ArticleArticleTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleArticleTag_ArticleTags_TagsId",
                table: "ArticleArticleTag",
                column: "TagsId",
                principalTable: "ArticleTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTopicPreference_ArticleTags_TagId",
                table: "UserTopicPreference",
                column: "TagId",
                principalTable: "ArticleTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
