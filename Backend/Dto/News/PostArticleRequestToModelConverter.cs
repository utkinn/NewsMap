using NetTopologySuite.Geometries;
using NewsMap.Model.News;
using NewsMap.Repositories.News;

namespace NewsMap.Dto.News;

public class PostArticleRequestToModelConverter(ArticleTagRepository tagRepository)
{
    public async Task<Article> ToModelAsync(PostArticleRequest dto) => new()
    {
        Title = dto.Title,
        Content = dto.Content,
        SourceUrl = dto.SourceUrl,
        Coordinates = new Point(new Coordinate(dto.Coordinates.Long, dto.Coordinates.Lat)),
        ImageUrl = dto.ImageUrl,
        DrawData = dto.DrawData,
        Importance = dto.Importance,
        PublishedAt = dto.PublishedAt,
        DisappearsAt = dto.DisappearsAt,
        Tags = (await tagRepository.ListByNamesAndCreateMissingAsync(dto.TagNames)).ToList()
    };
}