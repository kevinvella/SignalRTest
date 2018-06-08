using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SignalRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SignalRClient signalRClient = new SignalRClient();
            signalRClient.Message += SignalRClient_Message;

            while (true)
            {
                signalRClient.SendMessage("Test...").Wait();
            }
        }

        static void SignalRClient_Message(object sender, MessageEventArgs e)
        {
            Debug.WriteLine($"SignalR - {e.Command}");
        }

    }
}
