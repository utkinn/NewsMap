using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NewsMap.Model.News;

namespace NewsMap.Repositories.News;

public class ArticleRepository(NewsMapDbContext dbContext)
{
	public ValueTask<Article?> TryGetByIdAsync(int id) => dbContext.Articles.FindAsync(id);

	public Task<Article[]> GetRelevantAtGivenDayAsync(
		DateTimeOffset dateTimeOffset,
		CancellationToken cancellationToken = default)
	{
		return dbContext.Articles
			.Include(a => a.Tags)
			.Where(a => a.PublishedAt <= dateTimeOffset && dateTimeOffset <= a.DisappearsAt)
			.ToArrayAsync(cancellationToken);
	}

	public Task<Article[]> GetPublishedAtGivenDayAsync(DateOnly date, CancellationToken cancellationToken = default)
	{
		var todayBegin = new DateTimeOffset(date, new TimeOnly(0, 0), TimeSpan.Zero);
		var todayEnd = new DateTimeOffset(date, new TimeOnly(23, 59), TimeSpan.Zero);
		return ArticlesWithTags
			.Where(a => todayBegin <= a.PublishedAt && a.PublishedAt <= todayEnd)
			.ToArrayAsync(cancellationToken);
	}

	public Task<Article[]> FullTextSearchAsync(string textQuery, CancellationToken cancellationToken = default) =>
		ArticlesWithTags
			.Where(a => a.SearchVector.Matches(textQuery))
			.ToArrayAsync(cancellationToken);

	private IIncludableQueryable<Article, List<ArticleTag>> ArticlesWithTags =>
		dbContext.Articles.Include(a => a.Tags);

	public async Task AddAsync(Article article)
	{
		await dbContext.AddAsync(article);
		await dbContext.SaveChangesAsync();
	}
}