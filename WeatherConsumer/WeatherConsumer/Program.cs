using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ConsumerConfig()
{
  BootstrapServers  = "localhost:9092",
  GroupId = "weather-consumer-group",
  AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("weather-topic");

var token = new CancellationTokenSource();

try
{
  while (true)
  {
    var response = consumer.Consume(token.Token);
    if (response.Message != null)
    {
      var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
      Console.WriteLine($"State: {weather.State}, Temp: {weather.Temperature}F");
    }
  }
}
catch (Exception e)
{
  Console.WriteLine(e);
  throw;
}

public record Weather(string State, int Temperature);