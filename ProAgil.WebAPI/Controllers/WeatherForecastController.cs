using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public readonly DataContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     var rng = new Random();
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = rng.Next(-20, 55),
    //         Summary = Summaries[rng.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    public async Task<ActionResult> Get()
    {
      try
      {
        var results =  await _context.Eventos.ToListAsync();
        return Ok(results);
      }
      catch(System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
      try
      {
        var results =  await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
        return Ok(results);
      }
      catch(System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
      }
    }
  }
}
