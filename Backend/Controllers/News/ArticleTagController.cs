using Microsoft.AspNetCore.Mvc;
using NewsMap.Dto.News;
using NewsMap.Repositories.News;

namespace NewsMap.Controllers.News;

[ApiController]
[Route("api/article-tags")]
public sealed class ArticleTagController(ArticleTagRepository articleTagRepository)
{
    [HttpGet]
    public Task<IEnumerable<ArticleTagResponse>> List() =>
        articleTagRepository.ListAsync().Select(t => new ArticleTagResponse(t));
}