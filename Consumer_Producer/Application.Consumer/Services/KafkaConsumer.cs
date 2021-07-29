using Confluent.Kafka;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application.Consumer.Services
{
    public class KafkaConsumer
    {

        public const String HOST = "127.0.0.1:9092";
        public const String KAFKA_TOPIC_NAME = "FRAUDE";
        IEnumerable<string> m_oEnum = new string[] { "FRAUDE", "EMAIL" };
        public const String CONSUMER_GROUP_ID = "teste_consumer_group";


        public void ReciveMessage()
        {
            Console.WriteLine("Aguardando ... ");

            ConsumerConfig conf = new ConsumerConfig
            {
                GroupId = CONSUMER_GROUP_ID,
                BootstrapServers = HOST,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                MaxPollIntervalMs = 60000

            };

            using var Consumer = new ConsumerBuilder<Ignore, string>(conf).Build();
            {
                Consumer.Subscribe(m_oEnum);

                CancellationTokenSource Cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    Cts.Cancel();

                };

                try
                {
                    while (true)

                    {
                        try
                        {
                            var Message = Consumer.Consume(Cts.Token);
                            Console.WriteLine(Message.Value);
                            Console.WriteLine("Partition: " + Message.Partition + "-" + Message.Offset);
                        }
                        catch (ConsumeException e)
                        {

                            Log.Logger.Error($"Error occured: {e.Error.Reason}");
                        }
                    }
                        
                 }
                catch (OperationCanceledException)
                {

                    Consumer.Close();
            }
            }
        }

    }
}
