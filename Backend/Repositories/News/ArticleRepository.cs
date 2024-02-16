using Microsoft.EntityFrameworkCore;
using NewsMap.Model.News;

namespace NewsMap.Repositories.News;

public class ArticleRepository(NewsMapDbContext dbContext)
{
	public IEnumerable<Article> GetRelevantAtGivenDay(DateOnly date)
	{
		var todayBegin = new DateTimeOffset(date, new TimeOnly(0, 0), TimeSpan.Zero);
		var todayEnd = new DateTimeOffset(date, new TimeOnly(23, 59), TimeSpan.Zero);
		return dbContext.Articles
			.Include(a => a.Tags)
			.Where(a => a.RelevantTo >= todayBegin && todayEnd >= a.RelevantFrom);
		// TODO: check Where clause for correctness
	}

	public IEnumerable<Article> GetPublishedAtGivenDay(DateOnly date)
	{
		var todayBegin = new DateTimeOffset(date, new TimeOnly(0, 0), TimeSpan.Zero);
		var todayEnd = new DateTimeOffset(date, new TimeOnly(23, 59), TimeSpan.Zero);
		return dbContext.Articles
			.Include(a => a.Tags)
			.Where(a => todayBegin <= a.PublishedAt && a.PublishedAt <= todayEnd);
	}

	public async Task AddAsync(Article article)
	{
		await dbContext.AddAsync(article);
		await dbContext.SaveChangesAsync();
	}
}