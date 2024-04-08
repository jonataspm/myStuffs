using Server;
using System.Net;
using System.Net.Sockets;

string ipAddress = "127.0.0.1";
int port = 9001;

Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{
    IPAddress localAddr = IPAddress.Parse(ipAddress);
    IPEndPoint localEndPoint = new IPEndPoint(localAddr, port);
    serverSocket.Bind(localEndPoint);

    serverSocket.Listen(10);
    Console.WriteLine("Servidor aguardando conexões...");
    int conectionCounts = 1;

    while (true) 
    {
        Console.WriteLine($"User #{conectionCounts++}");
        Socket clientSocket = serverSocket.Accept();
        Console.WriteLine($"Conectado! \nClient: {clientSocket.RemoteEndPoint}");

        new Thread(() => new ExecuteTRA(clientSocket).StartProcess()).Start();

    }
}
catch (Exception e)
{
    Console.WriteLine("Ocorreu um erro: " + e.ToString());
}
finally
{
    serverSocket.Close();
}