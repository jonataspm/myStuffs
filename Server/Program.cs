using Server;
using System.Net;
using System.Net.Sockets;

string ipAddress = "127.0.0.1";
int port = 9001;

try
{
    using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        IPAddress localAddr = IPAddress.Parse(ipAddress);
        IPEndPoint localEndPoint = new IPEndPoint(localAddr, port);
        serverSocket.Bind(localEndPoint);

        serverSocket.Listen(10);
        Console.WriteLine("Servidor aguardando conexões...");
        int connectionCount = 1;

        while (true)
        {
            Console.WriteLine($"User #{connectionCount++}");
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine($"Conectado! \nCliente: {clientSocket.RemoteEndPoint}\n");

            ThreadPool.QueueUserWorkItem(state => new ExecuteTRA(clientSocket).StartProcess());
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Ocorreu um erro: " + e.ToString());
}