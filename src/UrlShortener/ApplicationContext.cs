namespace UrlShortener;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<ShortUrl> ShortUrls { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortUrl>(builder =>
        {
            builder.HasIndex(s => s.Slug).IsUnique();
        });
    }
}