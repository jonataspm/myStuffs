using System;
using zFaculdade.Pilhas;

namespace zFaculdade
{
    public class MainStarter
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(12 % 12);
                Pilha pilha = new Pilha();
                pilha.Push(34);
                pilha.Push(15);
                pilha.Push(91);
                pilha.Push(23);
                pilha.Push(12);
                OrdemCrescente(pilha);
                Print(pilha);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção: {ex.ToString()}");
            }
        }

        public static void OrdemCrescente(Pilha pilha)
        {
            Pilha aux = new Pilha();
            int auxSec;
            bool isOk = true;
            bool confirmed = true;

            int value = pilha.Size();
            while (confirmed)
            {

                aux.Push(pilha.Pop());
                // pilha.Push(34);
                // pilha.Push(15);
                // pilha.Push(23);
                // pilha.Push(91);
                while (isOk)
                {
                    if (aux.Top() > pilha.Top())
                    {
                        aux.Push(pilha.Pop());
                        isOk = true;

                        if (value == aux.Size())
                        {
                            isOk = false;
                            confirmed = false;
                        }
                    }
                    else
                    {
                        auxSec = aux.Pop();
                        aux.Push(pilha.Pop());
                        aux.Push(auxSec);
                        isOk = false;

                    }

                }
                while (aux.Size() != 0)
                {
                    pilha.Push(aux.Pop());
                    isOk = true;
                }

            }




        }
        
        public static void Print(Pilha pilha)
        {

            while(pilha.Size() != 0)
            {
                Console.Write(pilha.Pop()+" ");
            }

        }
    }
}

