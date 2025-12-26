namespace UrlShortener.Handlers;

public static class Shorten
{
    public static void MapShorten(this IEndpointRouteBuilder router)
    {
        router.MapPost("/api/shorten", async (
            ShortenUrlRequest request,
            IUrlShortenerServices shortenService,
            HttpContext context
        ) =>
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return Results.BadRequest("URL is invalid");
            }

            var shortUrl = await shortenService.GenerateUniqueSlug(request.Url);
            var response = new ShortenUrlResponse(shortUrl, context);

            return Results.Ok(response);
        });
    }
}