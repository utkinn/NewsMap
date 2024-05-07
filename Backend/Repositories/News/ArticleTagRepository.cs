using Microsoft.EntityFrameworkCore;
using NewsMap.Model.News;

namespace NewsMap.Repositories.News;

public class ArticleTagRepository(NewsMapDbContext dbContext)
{
    public async Task<IEnumerable<ArticleTag>> ListAsync() => await dbContext.ArticleTags.ToArrayAsync();
    
    public async Task<IEnumerable<ArticleTag>> ListByNamesAndCreateMissingAsync(IEnumerable<string> names)
    {
        var existingTags = dbContext.ArticleTags.Where(t => names.Contains(t.Name)).ToArray();
        
        var newTagNames = names.Except(existingTags.Select(t => t.Name));
        var newTags = newTagNames.Select(n => new ArticleTag { Name = n }).ToArray();
        await dbContext.AddRangeAsync(newTags);
        
        return existingTags.Concat(newTags);
    }

    public async Task<IEnumerable<ArticleTag>> GetByIdsAsync(IEnumerable<int> ids) =>
        await dbContext.ArticleTags.Where(t => ids.Contains(t.Id)).ToArrayAsync();
}