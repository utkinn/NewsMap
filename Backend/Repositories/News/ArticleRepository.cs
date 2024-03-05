using Microsoft.EntityFrameworkCore;
using NewsMap.Model.News;

namespace NewsMap.Repositories.News;

public class ArticleRepository(NewsMapDbContext dbContext)
{
	public ValueTask<Article?> TryGetByIdAsync(int id) => dbContext.Articles.FindAsync(id);
	
	public IEnumerable<Article> GetRelevantAtGivenDay(DateTimeOffset dateTimeOffset)
	{
		return dbContext.Articles
			.Include(a => a.Tags)
			.Where(a => a.PublishedAt <= dateTimeOffset && dateTimeOffset <= a.DisappearsAt);
	}

	public IEnumerable<Article> GetPublishedAtGivenDayAndMatchingTextQuery(DateOnly date, string? textQuery)
	{
		var todayBegin = new DateTimeOffset(date, new TimeOnly(0, 0), TimeSpan.Zero);
		var todayEnd = new DateTimeOffset(date, new TimeOnly(23, 59), TimeSpan.Zero);
		var queryable = dbContext.Articles
			.Include(a => a.Tags)
			.Where(a => todayBegin <= a.PublishedAt && a.PublishedAt <= todayEnd);

		if (textQuery != null)
		{
			// ReSharper disable once EntityFramework.UnsupportedServerSideFunctionCall
			queryable = queryable.Where(a => a.SearchVector.Matches(textQuery));
		}

		return queryable;
	}

	public async Task AddAsync(Article article)
	{
		await dbContext.AddAsync(article);
		await dbContext.SaveChangesAsync();
	}
}