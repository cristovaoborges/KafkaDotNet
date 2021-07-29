using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;

namespace Applicarion.Consumer.JsonSerialization.Services
{
   public class JsonConsumer
    {
        public string HOST = "127.0.0.1:9092";
        public string topic = "EMAIL";



        public void RecebeMensagem()
        {
            ConsumerConfig config = new ConsumerConfig
            {
                BootstrapServers = HOST,
                GroupId = "grupo-json",

            };

            var jsonSerializerConfig = new JsonSerializerConfig
            {
                BufferBytes = 100
            };



            CancellationTokenSource cts = new CancellationTokenSource();
            var consumeTask = Task.Run(() =>
            {

                using (var consumer =
                    new ConsumerBuilder<Null, Person>(config)                    
                    .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                    .SetValueDeserializer(new JsonDeserializer<Person>().AsSyncOverAsync())
                    .Build())

                {
                    consumer.Subscribe(topic);

                    try
                    {
                        while(true)
                        {
                            try
                            {



                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }


                }





            });

        }


    }
}
