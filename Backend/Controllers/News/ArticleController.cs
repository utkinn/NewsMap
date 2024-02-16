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
	PostArticleRequestToModelConverter articleModelConverter)
{
	[HttpGet("/")]
	public IEnumerable<ArticleResponse> Get() =>
		articleRepository
			.GetRelevantAtGivenDay(DateOnly.FromDateTime(DateTime.Now))
			.Select(a => new ArticleResponse(a));

	[HttpGet("/for-list")]
	public IEnumerable<ArticleResponse> GetForList(
		[FromQuery, BindRequired, RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
		string date) =>
		articleRepository.GetPublishedAtGivenDay(DateOnly.Parse(date)).Select(a => new ArticleResponse(a));

	[HttpPost("/")]
	// TODO: Authorize
	public async Task Add([FromBody] PostArticleRequest article) =>
		await articleRepository.AddAsync(await articleModelConverter.ToModelAsync(article));
}