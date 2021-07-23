using Application.Productor.Services;
using System;
using System.Threading.Tasks;

namespace Application.Productor
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Preparando mensagens ... ");
            await KafkaProductor.SendMensage();
            Console.WriteLine("Mensagens Enviadas ... ");

        }
    }
}
