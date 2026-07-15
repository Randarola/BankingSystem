using System.Net;
using System.Net.Sockets;
using Banking.Server.Services;
using Banking.Infrastructure.Repositories;

namespace Banking.Server.Networking
{
    public class TcpServer
    {
        private readonly TcpListener _listener;
        private readonly AuthService _authService;
        public TcpServer(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _authService = new AuthService(new CustomerRepository());
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started. Listening for connections...");
            while (true)
            {
                var client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                HandleClient(client);
            }

        }

        private void HandleClient(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine("Request received.");
                string response = ProcessRequest(request);
                byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(response);

                stream.Write(responseBytes, 0, responseBytes.Length);
            }
        }

        private string ProcessRequest(string request)
        {
            string[] parts = request.Split('|');
            
            if(parts.Length == 0)
            {
                return "ERROR|Invalid request format";
            }

            switch (parts[0])
            {
                case "LOGIN":
                    if (parts.Length != 3)
                    {
                        return "ERROR|Invalid LOGIN request format";
                    }
                    string pesel = parts[1];
                    string password = parts[2];

                    var customer = _authService.Login(pesel, password);
                    return customer != null ? "LOGIN_SUCCESS" : "LOGIN_FAILED";

                default:
                    return "UNKNOWN_COMMAND";
            }
        }
    }
}
