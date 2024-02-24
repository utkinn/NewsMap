using NewsMap.Model.News;

namespace NewsMap.Dto.News;

public sealed class ArticleResponse(Article article)
{
	public int Id => article.Id;
	public string Title => article.Title;
	public string Content => article.Content;
	public string SourceUrl => article.SourceUrl;
	public string DrawData => article.DrawData;
	public double Importance => article.Importance;
	public DateTimeOffset PublishedAt => article.PublishedAt;
	public DateTimeOffset DisappearsAt => article.DisappearsAt;
	public IEnumerable<ArticleTagResponse> Tags => article.Tags.Select(t => new ArticleTagResponse(t));
}