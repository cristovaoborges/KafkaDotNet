using Application.Consumer.Services;
using System;

namespace Application.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
           
            KafkaConsumer Consumer = new KafkaConsumer();
            Consumer.ReciveMessage();
            Console.WriteLine("Consumido ...");
        }
    }
}
