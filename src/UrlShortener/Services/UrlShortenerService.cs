namespace UrlShortener.Services;

public class UrlShortenerService(ApplicationContext context) : IUrlShortenerServices
{
    private const int SlugLength = 6;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random random = new();

    public async Task<string> GenerateUniqueSlug()
    {
        while (true)
        {
            var slugChars = new char[SlugLength];

            for (int i = 0; i < SlugLength; i++)
            {
                var index = random.Next(Alphabet.Length - 1);
                slugChars[i] = Alphabet[index];
            }

            var slug = new string(slugChars);

            if (!await context.ShortUrls.AnyAsync(url => url.Slug == slug))
            {
                return new(slugChars);
            }
        }
    }
}