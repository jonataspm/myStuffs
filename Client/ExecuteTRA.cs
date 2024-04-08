using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ExecuteTRA
    {
        private readonly Socket client;
        public ExecuteTRA(Socket client) => this.client = client;
        public void Menu()
        {
            string menu = " ___________________ \n" +
                          "|       M E N U     |\n" +
                          "| ----------------- |\n" +
                          "| 1 - Somar         |\n" +
                          "| 2 - Subtração     |\n" +
                          "| 3 - Multiplicar   |\n" +
                          "| 4 - Dividir       |\n" +
                          "| 0 - Sair          |\n" +
                          " ------------------- \n";


            int choice;
            do
            {
                Thread.Sleep(1000);
                string message, response;
                Console.WriteLine(menu);
                Console.Write("| Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("| Opção inválida. Por favor, escolha uma opção válida.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        message = GetProtocol("+");
                        SendProtocol(message);
                        response = ReciveResponse();
                        break;
                    case 2:
                        message = GetProtocol("-");
                        SendProtocol(message);
                        response = ReciveResponse();
                        break;
                    case 3:
                        message = GetProtocol("*");
                        SendProtocol(message);
                        response = ReciveResponse();
                        break;
                    case 4:
                        message = GetProtocol("/");
                        SendProtocol(message);
                        response = ReciveResponse();
                        break;
                    case 0:
                        SendProtocol("!");
                        response = "Você escolheu Sair. Adeus!";
                        break;
                    default:
                        response = "Opção inválida. Por favor, escolha uma opção válida.";
                        break;
                }

                Console.WriteLine($"| Resultado: {response}");
                Console.WriteLine($"| Pressione para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (choice != 0);
        }

        private void SendProtocol(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            client.SendAsync(messageBytes, SocketFlags.None);
        }

        private string ReciveResponse()
        {
            var buffer = new byte[1_024];
            var received = client.Receive(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);

            return response;
        }

        private static string GetProtocol(string op)
        {
            Console.Write("| Digite o primeiro número: ");
            string n1 = Console.ReadLine();

            Console.Write("| Digite o segundo número: ");
            string n2 = Console.ReadLine();

            return $"{op}{n1};{n2}";
        }
    }
}
