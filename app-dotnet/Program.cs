using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Json(new { status = "ok", service = "dotnet-minapi", message = "Hej från .NET Minimal API!" }));
app.MapGet("/health", () => Results.Ok("healthy"));

app.Run("http://0.0.0.0:8080");
