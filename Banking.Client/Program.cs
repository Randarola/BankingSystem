using System.Net.Sockets;
namespace Banking.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("", 5000);
                Console.WriteLine("Connected to the server.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Connection failed: {e.Message}");
            }

        }
    }
}
