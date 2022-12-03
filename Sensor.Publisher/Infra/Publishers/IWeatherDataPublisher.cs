using Sensor.Publisher.Models;

namespace Sensor.Publisher.Infra.Publishers;

public interface IWeatherDataPublisher
{
    Task ProduceAsync(Weather weather);
}