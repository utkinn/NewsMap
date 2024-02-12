using NewsMap.Model.News;

namespace NewsMap.Dto.News;

public class ArticleTagResponse
{
	public int Id { get; init; }
	public string Name { get; set; }

	public ArticleTagResponse(ArticleTag tag)
	{
		Id = tag.Id;
		Name = tag.Name;
	}
}