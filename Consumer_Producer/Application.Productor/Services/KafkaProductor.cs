using Confluent.Kafka;
using Consumer_Producer.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productor.Services
{
    public class KafkaProductor
    {
        public const String HOST = "127.0.0.1:9092";
        public const String KAFKA_TOPIC_NAME = "NEW_ORDER";
        public const String KAFKA_TOPIC_NAME2 = "SEND_EMAIL";
        public const int TIME_DELAY = 1000;


        public static async Task SendMensage()
        {

            
            var Conf = new ProducerConfig { BootstrapServers = HOST };

            using var Producer = new ProducerBuilder<Null, string>(Conf).Build();
            {
                try
                {

                    for (int i = 0; i < 50; i++)
                    {
                        Message Msg = new Message();
                        
                        string key = GerarKey();
                        var Message = await Producer.ProduceAsync(KAFKA_TOPIC_NAME,
                            new Message<Null, string> { Value = Msg.GetText() }
                           );

                    }
                        

                    //var Message2 = await Producer.ProduceAsync(KAFKA_TOPIC_NAME2,
                    //     new Message<Null, string> { Value = Msg.GetText2() });

                                    

                }
                catch (ProduceException<Null,string> e)
                {

                    Log.Logger.Error($"Ocorreu um erro: {e.Error.Reason}");
                }
            }

        }


        public static string GerarKey()
        {
            string key = Guid.NewGuid().ToString();
            return key;
        }
    }
}
