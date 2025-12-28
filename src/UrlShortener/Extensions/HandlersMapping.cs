namespace UrlShortener.Extensions;

public static class HandlersMapping
{
    public static void MapHandlers(this IEndpointRouteBuilder app)
    {
        app.MapShorten();
        app.MapRedirect();
    }
}