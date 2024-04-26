using Microsoft.EntityFrameworkCore;

namespace NewsMap.Model.News;

[PrimaryKey(nameof(Name))]
public sealed class ArticleTag
{
    public required string Name { get; set; }
    public List<Article> Articles { get; set; } = null!;
}