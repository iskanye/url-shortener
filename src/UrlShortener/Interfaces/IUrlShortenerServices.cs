namespace UrlShortener.Interfaces;

public interface IUrlShortenerServices
{
    public Task<ShortUrl> GenerateUniqueSlug(string url);
}