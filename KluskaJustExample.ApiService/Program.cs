using kluska;
using kluska.ApiService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KluskaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("KluskaDbContext") ?? throw new InvalidOperationException("Connection string 'KluskaDbContext' not found.")));

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddMvcCore();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // /ApplyDatabaseMigrations
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (KluskaDbContext dbContext) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            index,
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    forecast = dbContext.WeatherForecast.ToArray();
    return forecast;
});

app.MapDefaultEndpoints();
app.MapControllers();

app.Run();
