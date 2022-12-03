using Confluent.Kafka;
using Newtonsoft.Json;
using Sensor.Publisher.Models;

namespace Sensor.Publisher.Infra.Publishers;

public class WeatherDataPublisher : IWeatherDataPublisher
{
    private const string TopicName = "weather-topic"; 
    private readonly IProducer<Null, string> _producer;

    public WeatherDataPublisher(IProducer<Null, string> producer)
    {
        this._producer = producer;
    }

    public async Task ProduceAsync(Weather weather) =>
        await _producer.ProduceAsync(TopicName, new Message<Null, string>
        {
            Value = JsonConvert.SerializeObject(weather)
        });
}