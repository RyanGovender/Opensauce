using Microsoft.AspNetCore.Mvc;
using Opensauce.Infrastructure.Data.MongoDb;

namespace Opensauce.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IGitHubUserApi _githubApi;
    private readonly IMongoBase _mongo;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IGitHubUserApi gitHubApi, IMongoBase mongoBase)
    {
        _logger = logger;
        _githubApi = gitHubApi;
        _mongo = mongoBase;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(string username)
    {
        var result = await _githubApi.GetUserAsync(username);

        var mongoResulr =  _mongo.FindData<ProgrammingLanguage>("ProgrammingLanguages");

        return Ok(new {
            git = result,
            mongo = mongoResulr
        });
    }
}
