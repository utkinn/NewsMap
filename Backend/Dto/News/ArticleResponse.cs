using NewsMap.Model.News;

namespace NewsMap.Dto.News;

public class ArticleResponse
{
	public int Id { get; init; }
	public string Title { get; set; }
	public string Content { get; set; }
	public string SourceUrl { get; set; }
	public string DrawData { get; set; }
	public double Importance { get; set; }
	public DateTimeOffset PublishedAt { get; set; }
	public DateTimeOffset? RelevantFrom { get; set; }
	public DateTimeOffset? RelevantTo { get; set; }
	public DateTimeOffset DisappearsAt { get; set; }
	public IEnumerable<ArticleTagResponse> Tags { get; set; }

	public ArticleResponse(Article article)
	{
		Id = article.Id;
		Title = article.Title;
		Content = article.Content;
		SourceUrl = article.SourceUrl;
		DrawData = article.DrawData;
		Importance = article.Importance;
		PublishedAt = article.PublishedAt;
		RelevantFrom = article.RelevantFrom;
		RelevantTo = article.RelevantTo;
		DisappearsAt = article.DisappearsAt;
		Tags = article.Tags.Select(t => new ArticleTagResponse(t));
	}
}