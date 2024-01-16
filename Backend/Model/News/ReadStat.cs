using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NewsMap.Model.News;

[PrimaryKey(nameof(UserId), nameof(ArticleId))]
public class ReadStat
{
    public required int UserId { get; init; }
    public required IdentityUser User { get; init; }
    public required int ArticleId { get; init; }
    public required Article Article { get; init; }
    public required TimeSpan ReadTime { get; init; }
}