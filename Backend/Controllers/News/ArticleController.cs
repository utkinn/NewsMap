using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewsMap.Dto.News;
using NewsMap.Repositories.News;

namespace NewsMap.Controllers.News;

[ApiController]
[Route("api/articles")]
public class ArticleController(
	ArticleRepository articleRepository,
	PostArticleRequestToModelConverter articleModelConverter) : ControllerBase
{
	[HttpGet]
	public IEnumerable<ArticleResponse> Get() =>
		articleRepository
			.GetRelevantAtGivenDay(DateTimeOffset.UtcNow)
			.Select(a => new ArticleResponse(a));

	[HttpGet("for-list")]
	public IEnumerable<ArticleResponse> GetForList(
		[FromQuery, RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
		string? date,
		[FromQuery(Name = "q")] string? textQuery) =>
		articleRepository
			.GetPublishedAtGivenDayAndMatchingTextQuery(
				DateOnly.Parse(date ?? DateTime.Now.ToString("yyyy-MM-dd")),
				textQuery)
			.Select(a => new ArticleResponse(a));

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetById(int id)
	{
		var article = await articleRepository.TryGetByIdAsync(id);
		if (article == null)
			return NotFound();

		return Ok(new ArticleResponse(article));
	}

	[HttpPost]
	// TODO: Authorize
	public async Task Add([FromBody] PostArticleRequest article) =>
		await articleRepository.AddAsync(await articleModelConverter.ToModelAsync(article));
}