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
        public async Task Menu()
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
                Task.Delay(1000);
   
                Console.WriteLine(menu);
                Console.Write("| Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("| Opção inválida. Por favor, escolha uma opção válida.");
                    continue;
                }

                string message = choice == 0 ? "!" : GetProtocol((choice == 1 ? "+" : (choice == 2 ? "-" : (choice == 3 ? "*" : "/"))));
                await SendProtocol(message);
                string response = choice == 0 ? "Você escolheu Sair. Adeus!" : ReceiveResponse();

                Console.WriteLine($"| Resultado: {response}");
                Console.WriteLine($"| Pressione para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (choice != 0);
        }

        private async Task SendProtocol(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(messageBytes, SocketFlags.None);
        }

        private string ReceiveResponse()
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
