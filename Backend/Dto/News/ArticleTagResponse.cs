using NewsMap.Model.News;

namespace NewsMap.Dto.News;

public sealed class ArticleTagResponse(ArticleTag tag)
{
	public int Id => tag.Id;
	public string Name => tag.Name;
}