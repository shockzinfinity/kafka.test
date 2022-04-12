using Confluent.Kafka;

string kafkaEndpoint = "127.0.0.1:9092";
string kafkaTopic = "testtopic";

var consumerConfig = new ConsumerConfig
{
  BootstrapServers = kafkaEndpoint,
  GroupId = "foo",
  AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build()) {
  consumer.Subscribe(kafkaTopic);

  var cancelled = false;
  Console.CancelKeyPress += (_, e) =>
  {
    Console.WriteLine("Canceling");
    e.Cancel = true;
    cancelled = true;
  };

  Console.WriteLine("Ctrl-C to exit");

  while (!cancelled) {
    var consumeResult = consumer.Consume();
    Console.WriteLine(consumeResult.Message.Value);
  }
}

Console.ReadLine();
