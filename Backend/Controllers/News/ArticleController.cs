using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewsMap.Auth;
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
	public Task<IEnumerable<ArticleResponse>> GetAsync() =>
		articleRepository
			.GetRelevantAtGivenDayAsync(DateTimeOffset.UtcNow)
			.Select(a => new ArticleResponse(a));

	[HttpGet("for-list")]
	public Task<IEnumerable<ArticleResponse>> GetForListAsync(
		[FromQuery, RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
		string? date) =>
		articleRepository
			.GetPublishedAtGivenDayAsync(DateOnly.Parse(date ?? DateTime.Now.ToString("yyyy-MM-dd")))
			.Select(a => new ArticleResponse(a));

	[HttpGet("search")]
	public Task<IEnumerable<ArticleResponse>> SearchAsync([FromQuery(Name = "q"), BindRequired] string textQuery) =>
		articleRepository
			.FullTextSearchAsync(textQuery)
			.Select(a => new ArticleResponse(a));

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetById(int id)
	{
		var article = await articleRepository.TryGetByIdAsync(id);
		return article == null ? NotFound() : Ok(new ArticleResponse(article));
	}

	[HttpPost]
	[Authorize(Roles = Roles.Administrator)]
	public async Task Add([FromBody] PostArticleRequest article) =>
		await articleRepository.AddAsync(await articleModelConverter.ToModelAsync(article));
}