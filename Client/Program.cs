using System.Net.Sockets;
using System.Net;
using System.Text;
using Client;


do
{
    try
    {
        Console.Write("| Digite o endereço IP: ");
        string ipAddress = Console.ReadLine();

        Console.Write("| Digite a porta do endereço: ");
        int port = int.Parse(Console.ReadLine());

        IPAddress localAddr = IPAddress.Parse(ipAddress);
        IPEndPoint ipEndPoint = new IPEndPoint(localAddr, port);

        using Socket client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        Console.WriteLine("| Aguardando Conexão...");
        await client.ConnectAsync(ipEndPoint);
        Console.WriteLine("| Conectado!");

        var execute = new ExecuteTRA(client);
        execute.Menu();

        client.Shutdown(SocketShutdown.Both);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"| Erro no Sitema: {ex.Message} \n");
    }

} while (true);