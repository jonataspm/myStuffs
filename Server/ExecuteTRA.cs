using Server.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ExecuteTRA
    {
        private readonly Socket client;
        public ExecuteTRA(Socket client) => this.client = client;
        public void StartProcess()
        {
            try
            {
                byte[] responseBytes = new byte[256];
                char[] responseChars = new char[256];
                while (true)
                {
                    try
                    {
                        string clienteMenssage = GetMenssage();

                        string operatoR = clienteMenssage.Substring(0, 1);
                        
                        if (operatoR == "!")
                            break;

                        clienteMenssage = clienteMenssage.Substring(1);
                        string[] operationals = clienteMenssage.Split(";");

                        decimal result = 0;
                        int op1 = int.Parse(operationals[0]);
                        int op2 = int.Parse(operationals[1]);

                        result = GetResultOperation(operatoR, op1, op2);
                        
                        SendMenssage($"{result}");
                    }
                    catch (OperatorException ex)
                    {
                        SendMenssage(ex.Message);
                        LogGenerator.CreateLogError(ex, "StartProcess");
                    }
                    catch (FormatException ex)
                    {
                        SendMenssage("Revise as informações enviadas");
                        LogGenerator.CreateLogError(ex, "StartProcess");
                    }
                    catch (ArithmeticException ex)
                    {
                        SendMenssage(ex.Message);
                        LogGenerator.CreateLogError(ex, "StartProcess");
                    }
                    catch (SocketException ex)
                    {
                        LogGenerator.CreateLogError(ex, "ExecuteTRA - StartProcess");
                        break;
                    }
                    catch (Exception ex)
                    {
                        SendMenssage("Houve um erro no sistema, por favor aguarde um momento.");
                        LogGenerator.CreateLogError(ex, "StartProcess");
                        break;
                    }
                }

                Console.WriteLine($"\nCliente: {client.RemoteEndPoint}\nMensagem: Conexão fechada!");
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCliente: {client.RemoteEndPoint}\nMensagem: Conexão fechada!\nMotivo: {ex.Message}");
                client.Close();

                LogGenerator.CreateLogError(ex, "ExecuteTRA - StartProcess");
            }
        }

        private static decimal GetResultOperation(string operatoR, int op1, int op2) => operatoR switch
        {
            "+" => op1 + op2,
            "-" => op1 - op2,                
            "*" => op1 * op2,                
            "/" => op1 / op2,
            _ => throw new OperatorException("A operação é inválida!")
        };

        private async void SendMenssage(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _ = await client.SendAsync(messageBytes, SocketFlags.None);
            Console.WriteLine($"\nCliente: {client.RemoteEndPoint}\nMensagem Enviada: \"{message}\"");
        }

        private string GetMenssage()
        { 
            var buffer = new byte[1024];

            var received = client.Receive(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);

            Console.WriteLine($"\nCliente: {client.RemoteEndPoint}\nMensagem Recebida: {response}");
            return response;
        }
    }
}
