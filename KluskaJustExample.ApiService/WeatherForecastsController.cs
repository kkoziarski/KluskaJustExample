using kluska.ApiService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kluska.ApiService;

[Route("api/[controller]")]
[ApiController]
public class WeatherForecastsController : ControllerBase
{
    private readonly KluskaDbContext _context;

    public WeatherForecastsController(KluskaDbContext context)
    {
        _context = context;
    }

    // GET: api/WeatherForecasts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
    {
        return await _context.WeatherForecast.ToListAsync();
    }

    // GET: api/WeatherForecasts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(long id)
    {
        var weatherForecast = await _context.WeatherForecast.FindAsync(id);

        if (weatherForecast == null)
        {
            return NotFound();
        }

        return weatherForecast;
    }

    // PUT: api/WeatherForecasts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWeatherForecast(long id, WeatherForecast weatherForecast)
    {
        if (id != weatherForecast.Id)
        {
            return BadRequest();
        }

        _context.Entry(weatherForecast).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WeatherForecastExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/WeatherForecasts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
    {
        _context.WeatherForecast.Add(weatherForecast);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
    }

    // DELETE: api/WeatherForecasts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWeatherForecast(long id)
    {
        var weatherForecast = await _context.WeatherForecast.FindAsync(id);
        if (weatherForecast == null)
        {
            return NotFound();
        }

        _context.WeatherForecast.Remove(weatherForecast);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WeatherForecastExists(long id)
    {
        return _context.WeatherForecast.Any(e => e.Id == id);
    }
}
