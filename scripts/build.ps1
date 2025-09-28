# Bygg .NET Minimal API och Docker image
dotnet build ..\app-dotnet\app-dotnet.csproj -c Release
docker build -t clo24-minapi:local ..\app-dotnet
