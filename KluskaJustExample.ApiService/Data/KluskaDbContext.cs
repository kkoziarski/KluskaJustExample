using Microsoft.EntityFrameworkCore;

namespace kluska.ApiService.Data;

public class KluskaDbContext : DbContext
{
    public KluskaDbContext(DbContextOptions<KluskaDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WeatherForecast>().HasData(
            new WeatherForecast(1, new DateOnly(2024, 9, 1), 25, "Sunny"),
            new WeatherForecast(2, new DateOnly(2024, 9, 2), 18, "Cloudy"),
            new WeatherForecast(3, new DateOnly(2024, 9, 3), 22, "Partly cloudy"),
            new WeatherForecast(4, new DateOnly(2024, 9, 4), 15, "Rainy"),
            new WeatherForecast(5, new DateOnly(2024, 9, 5), 30, "Hot")
        );
    }

    public DbSet<kluska.WeatherForecast> WeatherForecast { get; set; } = default!;
}
