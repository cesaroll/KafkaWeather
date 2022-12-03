using Microsoft.AspNetCore.Mvc;
using Sensor.Publisher.Infra.Publishers;
using Sensor.Publisher.Models;

namespace Sensor.Publisher.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly ILogger<SensorController> _logger;
    private readonly IWeatherDataPublisher _weatherDataPublisher;

    public SensorController(ILogger<SensorController> logger, IWeatherDataPublisher weatherDataPublisher)
    {
        _logger = logger;
        _weatherDataPublisher = weatherDataPublisher;
    }

    // POST api/<SensorControler>
    [HttpPost]
    public async Task Post([FromBody] Weather weather)
    {
        await _weatherDataPublisher.ProduceAsync(weather);
    }
    
}