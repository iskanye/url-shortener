namespace UrlShortener.Models;

public class ShortenUrlResponse(ShortUrl shortUrl, HttpContext context)
{
    public Guid If { get; set; } = shortUrl.Id;
    public string ShortUrl { get; set; } = $"{context.Request.Scheme}://{context.Request.Host}/{shortUrl.Slug}";
}