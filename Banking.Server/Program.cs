using Banking.Server.Networking;

namespace Banking.Server;

internal class Program
{
    static void Main(string[] args)
    {
        var server = new TcpServer(5000);

        server.Start();
    }
}