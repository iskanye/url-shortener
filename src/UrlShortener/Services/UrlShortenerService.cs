namespace UrlShortener.Services;

public class UrlShortenerService : IUrlShortenerServices
{
    private const int SlugLength = 6;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random random = new();

    public string GenerateUniqueSlug()
    {
        var slug = new char[SlugLength];

        for (int i = 0; i < SlugLength; i++)
        {
            var index = random.Next(Alphabet.Length - 1);
            slug[i] = Alphabet[index];
        }

        return new(slug);
    }
}