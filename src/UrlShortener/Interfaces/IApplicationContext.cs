namespace UrlShortener.Interfaces;

public interface IApplicationContext
{
    public DbSet<ShortUrl> ShortUrls { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken token = default);
}