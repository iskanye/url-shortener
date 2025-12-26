namespace UrlShortener;

public static class DependencyInjection
{
    public static void AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IApplicationContext, ApplicationContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
        builder.Services.AddScoped<IUrlShortenerServices, UrlShortenerService>();
    }
}