using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsMap.Model;
using NewsMap.Model.News;

namespace NewsMap;

public class NewsMapDbContext(DbContextOptions<NewsMapDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<ArticleTag> ArticleTags => Set<ArticleTag>();
}