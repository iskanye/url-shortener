FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

COPY . .
RUN dotnet publish "src/UrlShortener/UrlShortener.csproj" -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV DOTNET_RUNNING_IN_CONTAINER=true

COPY --from=build /app/publish ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "UrlShortener.dll"]