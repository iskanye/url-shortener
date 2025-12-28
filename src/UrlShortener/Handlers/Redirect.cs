namespace UrlShortener.Handlers;

public static class Redirect
{
    public static void MapRedirect(this IEndpointRouteBuilder router)
    {
        router.MapPost("{slug}", async (
            string slug,
            IApplicationContext context
        ) =>
        {
            var shortUrl = await context
                .ShortUrls
                .SingleOrDefaultAsync(s => s.Slug == slug);

            if (shortUrl is null)
            {
                return Results.NotFound();
            }

            return Results.Redirect(shortUrl.Url);

        });
    }
}