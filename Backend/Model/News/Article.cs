using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
using NpgsqlTypes;

namespace NewsMap.Model.News;

public sealed class Article
{
    [Required] public int Id { get; init; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required Point Coordinates { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }
    public required string SourceUrl { get; set; }
    public required string ImageUrl { get; set; }
    public required string DrawData { get; set; }
    public required double Importance { get; set; }
    public required DateTimeOffset PublishedAt { get; set; }
    public required DateTimeOffset DisappearsAt { get; set; }
    public List<ArticleTag> Tags { get; set; } = [];
}