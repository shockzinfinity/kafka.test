// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;

Console.WriteLine("Hello, World!");

string kafkaEndpoint = "127.0.0.1:9092";
string kafkaTopic = "testtopic";

var confluentConfig = new ProducerConfig
{
  BootstrapServers = kafkaEndpoint,
};

Random random = new Random();

using (var producer = new ProducerBuilder<Null, string>(confluentConfig).Build()) {
  for (int i = 0; i < 10000; i++) {
    var message = $"Event {i} : {random.Next(103949)}";
    //var t = producer.ProduceAsync(kafkaTopic, new Message<Null, string> { Value = message });
    //t.ContinueWith(task =>
    //{
    //  if (task.IsFaulted) {
    //  } else {
    //    Console.WriteLine($"Wrote to offset: {task.Result.Offset}");
    //  }
    //});
    Thread.Sleep(50);
    Console.WriteLine($"published: {message}");
    await producer.ProduceAsync(kafkaTopic, new Message<Null, string> { Value = message });
  }
}

Console.WriteLine("End produce message");
Console.ReadLine();