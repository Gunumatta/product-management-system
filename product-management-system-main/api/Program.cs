using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Home endpoint to check if API is working
app.MapGet("/", () => "API is working")
   .WithName("GetHome");

// Endpoint to calculate price with tax
app.MapGet("/price/{price:double}/{tax:double}", (double price, double tax) => {
    try {
        var final = price + (price * tax / 100);
        return Results.Json(new { Price = Math.Round(price, 2), Tax = $"{tax}%", Final = Math.Round(final, 2) });
    } catch (Exception ex) {
        Console.WriteLine($"Error calculating tax: {ex.Message}");
        return Results.Problem("Error calculating tax", statusCode: 500);
    }
})
.WithName("GetTax");


// Weather forecast endpoint
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
