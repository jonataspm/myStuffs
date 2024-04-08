using Client;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

        using (Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
        {
            Console.WriteLine("| Aguardando Conexão...");
            await client.ConnectAsync(ipEndPoint);
            Console.WriteLine("| Conectado!");

            var execute = new ExecuteTRA(client);
            execute.Menu();
        }

        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"| Erro no Sistema: {ex.Message}\n");
    }

} while (true);
