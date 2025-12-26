namespace UrlShortener.Interfaces;

public interface IUrlShortenerServices
{
    public Task<string> GenerateUniqueSlug();
}