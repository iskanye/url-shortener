namespace UrlShortener;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ShortUrl> ShortUrls { get; set; }
}