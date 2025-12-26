namespace UrlShortener.Services;

public class UrlShortenerService(IApplicationContext context) : IUrlShortenerServices
{
    private const int SlugLength = 6;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random random = new();

    public async Task<ShortUrl> GenerateUniqueSlug(string url)
    {
        string slug;

        while (true)
        {
            var slugChars = new char[SlugLength];

            for (int i = 0; i < SlugLength; i++)
            {
                var index = random.Next(Alphabet.Length - 1);
                slugChars[i] = Alphabet[index];
            }

            slug = new string(slugChars);

            if (!await context.ShortUrls.AnyAsync(url => url.Slug == slug))
            {
                break;
            }
        }

        var shortUrl = new ShortUrl
        {
            Id = new(),
            Url = url,
            Slug = slug
        };

        context.ShortUrls.Add(shortUrl);
        await context.SaveChangesAsync();

        return shortUrl;
    }
}