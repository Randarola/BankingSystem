using System.Net;
using System.Net.Sockets;

namespace Banking.Server.Networking
{
    public class TcpServer
    {
        private readonly TcpListener _listener;
        public TcpServer(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started. Listening for connections...");
            while (true)
            {
                var client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");
            }
        }
    }
}
