namespace NewsMap.Dto.News;

public sealed class PostArticleRequest
{
    /// <summary>Заголовок новости.</summary>
    public required string Title { get; set; }

    /// <summary>Текст новости.</summary>
    public required string Content { get; set; }

    public required string ImageUrl { get; set; }

    /// <summary>Ссылка на источник.</summary>
    public required string SourceUrl { get; set; }

    /// <summary>
    /// JSON в свободной форме. Используется клиентской частью для отрисовки новости на карте в виде метки или полигона.
    /// </summary>
    public string DrawData { get; set; } = "";

    public required CoordinatesDto Coordinates { get; set; }

    /// <summary>Коэффициент важности новости. Влияет на порядок новости в списке.</summary>
    public double Importance { get; set; } = 0;

    /// <summary>Время публикации новости.</summary>
    public required DateTimeOffset PublishedAt { get; set; }

    /// <summary>
    /// Момент, после которого новость исчезнет с карты и станет доступна только через поиск в списке.
    /// </summary>
    public DateTimeOffset DisappearsAt { get; set; } = DateTimeOffset.Now + TimeSpan.FromDays(30);

    /// <summary>
    /// Категории новости, к которым она относится. Новость может относиться к нескольким категориям.
    /// </summary>
    public List<string> TagNames { get; set; } = [];
}