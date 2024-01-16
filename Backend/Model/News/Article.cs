namespace NewsMap.Model.News;

public sealed class Article
{
    public required int Id { get; init; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string SourceUrl { get; set; }
    public required string DrawData { get; set; }
    public required double Importance { get; set; }
    public required DateTimeOffset PublishedAt { get; set; }
    public DateTimeOffset? RelevantFrom { get; set; }
    public DateTimeOffset? RelevantTo { get; set; }
    public required DateTimeOffset DisappearsAt { get; set; }
    public List<ArticleTag> Tags { get; set; } = [];
}