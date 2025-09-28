# .NET 8 Minimal API i container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["app-dotnet.csproj", "./"]
RUN dotnet restore "app-dotnet.csproj"
COPY . .
RUN dotnet publish "app-dotnet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "app-dotnet.dll"]
