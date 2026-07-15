using System.Net.Sockets;
using System.Text;

namespace Banking.Client;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            TcpClient client = new TcpClient();

            client.Connect("127.0.0.1", 5000);

            Console.WriteLine("Connected to server.");
                
            NetworkStream stream = client.GetStream();

            string request = "LOGIN|12345678901|test1";

            byte[] requestBytes = Encoding.UTF8.GetBytes(request);

            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] buffer = new byte[1024];

            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string response = Encoding.UTF8.GetString(
                buffer,
                0,
                bytesRead);

            Console.WriteLine($"Server response: {response}");

            client.Close();
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Connection error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
