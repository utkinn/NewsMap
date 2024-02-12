using System.ComponentModel.DataAnnotations;

namespace NewsMap.Model.News;

public sealed class ArticleTag
{
    [Required] public int Id { get; init; }
    public required string Name { get; set; }
    public List<Article> Articles { get; set; } = null!;
}