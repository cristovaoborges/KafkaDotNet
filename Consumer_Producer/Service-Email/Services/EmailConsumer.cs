using Confluent.Kafka;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Service_Email.Services
{
    public class EmailConsumer
    {

        public const String HOST = "127.0.0.1:9092";
        public const String TOPIC = "EMAIL";
        public const String EMAILGROUP = "EMAILGROUPID";



        public void ReceivedMessenger()
        {
            Console.WriteLine("Aguardando Mensagens... ");

            ConsumerConfig config = new ConsumerConfig()
            {
                GroupId = EMAILGROUP,
                BootstrapServers = HOST,
                AutoOffsetReset = AutoOffsetReset.Earliest
                

            };

            using var Consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            {
                Consumer.Subscribe(TOPIC);
                CancellationTokenSource cancellation = new CancellationTokenSource();
                Console.CancelKeyPress += (_,e) =>
                {
                    e.Cancel = true;
                    cancellation.Cancel();
                
                };

                try
                {
                    while(true)
                    {
                        try
                        {

                            var Message = Consumer.Consume(cancellation.Token);
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
