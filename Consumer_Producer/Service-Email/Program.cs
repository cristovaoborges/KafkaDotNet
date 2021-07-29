using Service_Email.Services;
using System;

namespace Service_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailConsumer emailConsumer = new EmailConsumer();
            emailConsumer.ReceivedMessenger();
            Console.WriteLine("... ... ... ");
        }
    }
}
