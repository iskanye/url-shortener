namespace UrlShortener.Entities;

[Index("Slug", IsUnique = true)]
public class ShortUrl
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}