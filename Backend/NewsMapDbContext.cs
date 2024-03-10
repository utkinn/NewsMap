using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsMap.Model;
using NewsMap.Model.News;

namespace NewsMap;

public class NewsMapDbContext(DbContextOptions<NewsMapDbContext> options) : IdentityDbContext<User>(options)
{
	public DbSet<Article> Articles => Set<Article>();
	public DbSet<ArticleTag> ArticleTags => Set<ArticleTag>();

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		builder
			.Entity<Article>()
			.HasGeneratedTsVectorColumn(
				a => a.SearchVector,
				"russian",
				a => new { a.Title, a.Content })
			.HasIndex(a => a.SearchVector)
			.HasMethod("GIN");
		
		builder
			.Entity<UserTopicPreference>()
			.HasOne(p => p.User)
			.WithMany(u => u.TopicPreferences)
			.HasForeignKey(p => p.UserId);
	}
}